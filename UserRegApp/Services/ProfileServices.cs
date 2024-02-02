using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegApp.Entities;
using UserRegApp.Repositories;

namespace UserRegApp.Services
{
    internal class ProfileServices
    {
        private readonly ProfileRepository _profileRepository;
        private readonly UserService _userService;
        private readonly RoleService _roleService;

        public ProfileServices(ProfileRepository profileRepository, UserService userService, RoleService roleService)
        {
            _profileRepository = profileRepository;
            _userService = userService;
            _roleService = roleService;
        }

        public ProfileEntity CreateProfile(string FirstName, string LastName, string RoleName,string email, string phone, int addressid)
        {
            var roleEntity = _roleService.CreateRole(RoleName);
            var userEntity = _userService.CreateUser(email, phone, addressid);

            var profileEntity = new ProfileEntity
            {
                FirstName = FirstName,
                LastName = LastName,
                RoleId = roleEntity.Id,
                User = userEntity 
                
            };
            
            userEntity.Profile = profileEntity;

            return profileEntity;
        } 
            

    }
}
