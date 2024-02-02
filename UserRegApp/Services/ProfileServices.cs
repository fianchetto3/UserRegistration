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
            try
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
            catch { }
            return null!;


        }
        public ProfileEntity GetProfileByFirstName (string FirstName)
        {
            try
            {
                var profileEntity = _profileRepository.Read(x => x.FirstName == FirstName);
                return profileEntity;

            }
            catch { }
            return null!;
        }

        public ProfileEntity GetProfileByLastName (string LastName)
        {
            try
            {
                var profileEntity = _profileRepository.Read(x => x.LastName == LastName);
                return profileEntity;
   
            }
            catch { }
            return null!;

        }


        public ProfileEntity GetProfileById(int id)
        {
            var profileEntity = _profileRepository.Read(x => x.Id == id);
            return profileEntity;
        }

        public IEnumerable<ProfileEntity> GetProfiles()
        {
            var profiles = new List<ProfileEntity>();   
            return profiles;
        }

        public ProfileEntity UpdateProfile(ProfileEntity profileEntity)
        {
            var updateProfile = _profileRepository.Update(x => x.Id == profileEntity.Id, profileEntity);
            return updateProfile;
        }

        public void DeleteProfile (int id)
        {
            _profileRepository.Delete(x => x.Id == id);
        }

    }
}


