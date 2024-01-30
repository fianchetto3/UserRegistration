using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegApp.Entities;
using UserRegApp.Repositories;

namespace UserRegApp.Services
{
    internal class RoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public RoleEntity CreateRole(string roleName)         
        {
            var roleEntity = _roleRepository.Read(x => x.RoleName == roleName);
            roleEntity ??= _roleRepository.Create(new RoleEntity() { RoleName = roleName });
            return roleEntity;
        }

        public RoleEntity GetRoleByRoleName (string roleName)
        {
            var roleEntity = _roleRepository.Read(x => x.RoleName == roleName);
            return roleEntity;
        }

        public RoleEntity GetRoleByRoleId(int id)
        {
            var roleEntity = _roleRepository.Read(x => x.Id == id);
            return roleEntity;
        }

        public IEnumerable<RoleEntity> GetRoles() 
        {
            var roles = new List<RoleEntity>();
            return roles; 
        }

        public RoleEntity UpdateRole (RoleEntity roleEntity)
        {
            var updatedRoleEntity = _roleRepository.Update(x => x.Id == roleEntity.Id, roleEntity);
            return updatedRoleEntity;
        }

        public void DeleteRole (int id)
        {
            _roleRepository.Delete(x => x.Id == id);
        }

    }
}
