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

        public UserService(UserRepository userRepository, AddressService addressService)
        {
            _userRepository = userRepository;
            _addressService = addressService;
        }

        public UserEntity CreateUser(string email , string phone, string city, string postalcode, string street)
        {
            try
            {
                Debug.WriteLine("Creating Addres... ");
                var addressEntity = _addressService.CreateAddress(street, postalcode, city);
                if (addressEntity == null)
                {
                    Debug.WriteLine("Failed To create Address.");
                    return null!;
                }

                Debug.WriteLine("Creating User...");
                var userEntity = _userRepository.Read(x => email == x.Email && x.Phone == phone);
                if (userEntity == null)
                {
                    Debug.WriteLine("User Not found, Creating new User..");
                    userEntity = _userRepository.Create(new UserEntity() { Email = email, Phone = phone, AddressId = addressEntity.Id });

                }
                else
                {
                    Debug.WriteLine("User Found. Updating Address...");
                 
                   
                }
                Debug.WriteLine("User Created Successfully.");
                return userEntity;

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message);}
            return null!;
         
        }

        public UserEntity GetUserByEmail (string email)
        {
            var userEntity = _userRepository.Read(x => x.Email == email);
            return userEntity;
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

        internal UserEntity CreateUser(string email)
        {
            throw new NotImplementedException();
        }
    }
}
