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
    internal class UserActivityService
    {
        private readonly UserActivityRepository _userActivityRepository;
        private readonly UserRepository _userRepository;

        public UserActivityService(UserActivityRepository userActivityRepository, UserRepository userRepository)
        {
            _userActivityRepository = userActivityRepository;
            _userRepository = userRepository;
        }


        public UserActivityEntity CreateActivity(int userId, DateTime lastLoggedIn)
        {
            var user = _userRepository.Read(x => x.Id == userId);
            if (user == null)
            {
                
                return null;
            }

            var userActivityEntity = _userActivityRepository.Create(new UserActivityEntity
            {
                UserId = userId,
                LastLoggedIn = lastLoggedIn
            });

            return userActivityEntity;
        }



        public UserActivityEntity GetActivityByTime(DateTime lastLoggedIn)
        {
            var userActivityEntity = _userActivityRepository.Read(x => x.LastLoggedIn == lastLoggedIn);
            return userActivityEntity;
        }

        public UserActivityEntity GetActivityById(int id)
        {
            var userActivity = _userActivityRepository.Read(x => x.Id == id);
            return userActivity;
        }

        public IEnumerable<UserActivityEntity> GetAll()
        {
            var activites = new List<UserActivityEntity>();
            return activites;
        }

        public UserActivityEntity UpdateActivity(UserActivityEntity userActivity )
        {
            try
            {
                var existingActivity = _userActivityRepository.Read(x => x.Id == userActivity.Id);
                if (existingActivity == null)
                {
                    Console.WriteLine("Något gick fel vid uppdatering av Aktivitet");
                    return null;
                }
                existingActivity.LastLoggedIn = userActivity.LastLoggedIn;
                var updatedActivity = _userActivityRepository.Update(x => x.Id == existingActivity.Id, existingActivity);

                return updatedActivity;

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null;
            
            
        }

        public void DeleteRole(int id)
        {
            _userActivityRepository.Delete(x => x.Id == id);
        }



    }
}
