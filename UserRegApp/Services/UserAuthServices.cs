using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegApp.Entities;
using UserRegApp.Repositories;


namespace UserRegApp.Services
{
    internal class UserAuthServices
    {
        private readonly UserAuthRepository _userauthRepository;
        private readonly PasswordHasher _passwordHasher;
        private readonly UserService _userService;

        public UserAuthServices(UserAuthRepository userauthRepository, PasswordHasher passwordHasher, UserService userService)
        {
            _userauthRepository = userauthRepository;
            _passwordHasher = passwordHasher;
            _userService = userService;
        }

        public UserAuthEntity CreatePassword (int userId, string password)
        {
            try
            {
                var user = _userService.GetUserByUserId (userId);

                if (user == null)
                {
                    Debug.WriteLine("Användaren hittades inte");
                    return null!;
                }
                
                string hashedPassword = PasswordHasher.HashPassword(password);


                var userAuthEntity = _userauthRepository.Read(x => x.Id == userId);
                if (userAuthEntity == null)
                {
                    userAuthEntity = _userauthRepository.Create(new UserAuthEntity()
                    {
                        Id = userId,
                        Password= hashedPassword
                    });

                }
 
                return userAuthEntity;

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;

        }

        public UserAuthEntity GetPasswordById (int id)
        {
            var userAuthEntity = _userauthRepository.Read(x => x.Id == id);
            return userAuthEntity;
        }

        public IEnumerable<UserAuthEntity> GetPasswords()
        {
            var passwords = new List<UserAuthEntity>();
            return passwords;
        }

        public UserAuthEntity UpdatePasswords(UserAuthEntity userAuthEntity)
        {
            var updatedUserAuthEntity = _userauthRepository.Update(x => x.Id == userAuthEntity.Id, userAuthEntity);
            return updatedUserAuthEntity;
        }

        public void DeletetRole(int id)
        {
            _userauthRepository.Delete(x => x.Id == id);
        }
    }
}
