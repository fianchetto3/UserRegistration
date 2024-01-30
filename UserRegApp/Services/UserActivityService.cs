using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegApp.Entities;
using UserRegApp.Repositories;

namespace UserRegApp.Services
{
    internal class UserActivityService
    {
        private readonly UserActivityRepository _useractivityRepositroy;

        public UserActivityService(UserActivityRepository useractivityRepositroy)
        {
            _useractivityRepositroy = useractivityRepositroy;
        }
        public RoleEntity CreateRole(string lastLoggedIn)
        {
            var userActivityEntity = _useractivityRepositroy.Read(x => x.LastLoggedIn == lastLoggedIn);
            roleEntity ??= _useractivityRepositroy.Create(new RoleEntity() { RoleName = roleName });
            return roleEntity;
        }

        public RoleEntity GetRoleByRoleName(string roleName)
        {
            var roleEntity = _useractivityRepositroy.Read(x => x.RoleName == roleName);
            return roleEntity;
        }

        public RoleEntity GetRoleByRoleId(int id)
        {
            var roleEntity = _useractivityRepositroy.Read(x => x.Id == id);
            return roleEntity;
        }

        public IEnumerable<RoleEntity> GetRoles()
        {
            var roles = new List<RoleEntity>();
            return roles;
        }

        public RoleEntity UpdateRole(RoleEntity roleEntity)
        {
            var updatedRoleEntity = _useractivityRepositroy.Update(x => x.Id == roleEntity.Id, roleEntity);
            return updatedRoleEntity;
        }

        public void DeleteActivity(int id)
        {
            _useractivityRepositroy.Delete(x => x.Id == id);
        }

    }
}
