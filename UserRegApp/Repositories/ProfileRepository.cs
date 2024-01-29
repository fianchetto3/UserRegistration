using UserRegApp.Context;
using UserRegApp.Entities;

namespace UserRegApp.Repositories
{
    internal class ProfileRepository : Repo<ProfileEntity>
    {
        public ProfileRepository(DataContext context) : base(context)
        {
        }
    }

}

