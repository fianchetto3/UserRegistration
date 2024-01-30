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

        public UserEntity CreateUser(string email , string phone, int addressId )
        {
            try
            {
                var addressEntity = _addressService.GetAddressbyId(addressId);
                var userEntity = _userRepository.Read(x => x.Email == email && x.Phone == phone);
                userEntity ??= _userRepository.Create(new UserEntity() { Email = email, Phone = phone });
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



    }
}
