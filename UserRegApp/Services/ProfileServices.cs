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
    internal class ProfileServices
    {
        private readonly ProfileRepository _profileRepository;
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;

        public ProfileServices(ProfileRepository profileRepository, UserRepository userRepository, RoleRepository roleRepository)
        {
            _profileRepository = profileRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public ProfileEntity CreateProfile(string firstName, string lastName, string roleName)
        {
            try
            {
                var roleEntity = _roleRepository.Read(x => x.RoleName == roleName);

                if (roleEntity == null)
                {
                    Debug.WriteLine($"Role '{roleName}' does not exist.");
                    return null;
                }

                var profileEntity = _profileRepository.Read(x => x.FirstName == firstName && x.LastName == lastName);

                if (profileEntity == null)
                {
                    profileEntity = new ProfileEntity
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        RoleId = roleEntity.Id
                    };

                    profileEntity = _profileRepository.Create(profileEntity);
                    return profileEntity;
                }

                Debug.WriteLine("Profile already exists.");
                return profileEntity;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
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


