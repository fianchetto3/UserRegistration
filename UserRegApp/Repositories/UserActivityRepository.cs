using UserRegApp.Context;
using UserRegApp.Entities;

namespace UserRegApp.Repositories
{
    internal class UserActivityRepository : Repo<UserActivityEntity>
    {
        public UserActivityRepository(DataContext context) : base(context)
        {
        }
    }

}

