using System;
using System.Collections.Generic;
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

        public UserAuthServices(UserAuthRepository userauthRepository)
        {
            _userauthRepository = userauthRepository;
        }

        public UserAuthEntity CreatePassword (string password)
        {
            var userAuthEntity = _userauthRepository.Read(x => x.Password == password);
            userAuthEntity ??= _userauthRepository .Create(new UserAuthEntity() {Password = password });
            return userAuthEntity;
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
