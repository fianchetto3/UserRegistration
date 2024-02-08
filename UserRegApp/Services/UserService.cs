using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegApp.Entities;
using UserRegApp.Repositories;

namespace UserRegApp.Services
{
    internal class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly AddressService _addressService;
        private readonly UserActivityService _userActivityService;
        private readonly ProfileServices _profileServices;

        public UserService(UserRepository userRepository, AddressService addressService, UserActivityService userActivityService, ProfileServices profileServices)
        {
            _userRepository = userRepository;
            _addressService = addressService;
            _userActivityService = userActivityService;
            _profileServices = profileServices;
        }

        public UserEntity CreateUser(string email, string phone, string city, string postalcode, string street, string FirstName, string LastName)
        {
            try
            {
                Debug.WriteLine("Creating Address... ");
                var addressEntity = _addressService.GetAddressByStreet(street);
                if (addressEntity == null)
                {
                    addressEntity = _addressService.GetAddressByPostalCode(postalcode);
                    if (addressEntity == null)
                    {
                        addressEntity = _addressService.GetAddressByCity(city);
                    }
                }
                if (addressEntity == null)
                {
                    Debug.WriteLine("Failed to find existing address. Creating new address...");
                    addressEntity = _addressService.CreateAddress(street, postalcode, city);
                    if (addressEntity == null)
                    {
                        Debug.WriteLine("Failed to create address.");
                        return null!;
                    }
                }

        



                Debug.WriteLine("Creating User...");
                var userEntity = _userRepository.Read(x => email == x.Email && x.Phone == phone);
                if (userEntity == null)
                {
                    Debug.WriteLine("User Not found, Creating new User..");
                    userEntity = new UserEntity() { Email = email, Phone = phone, AddressId = addressEntity.Id };
                    userEntity = _userRepository.Create(userEntity);
                }
                else
                {
                    Debug.WriteLine("User Found. Updating Address...");
                    userEntity.AddressId = addressEntity.Id;
                    userEntity = _userRepository.Update(userEntity);
                }

                if (userEntity != null)
                {
                    var userActivityEntity = _userActivityService.CreateActivity(userEntity.Id, DateTime.Now);
                   
                }

                Debug.WriteLine("User Created Successfully.");
                return userEntity!;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
        }

        public UserEntity GetUserByEmail (string email)
        {
            try
            {
                var userEntity = _userRepository.Read(x => x.Email == email);
                return userEntity;

            }
            catch { }
            return null!;
        }

        public UserEntity GetUserByUserId(int id)
        {
            var userEntity = _userRepository.Read(x => x.Id == id);
            return userEntity;
        }

        public IEnumerable<UserEntity> GetUsers()
        {
            var users = new List<UserEntity>();
            return users;
        }

        public UserEntity UpdateUser(UserEntity userEntity)
        {
            var updatedRoleEntity = _userRepository.Update(x => x.Id == userEntity.Id, userEntity);
            return updatedRoleEntity;
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(x => x.Id == id);
        }


    }
}
