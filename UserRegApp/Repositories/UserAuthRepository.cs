using UserRegApp.Context;
using UserRegApp.Entities;

namespace UserRegApp.Repositories
{
    internal class UserAuthRepository : Repo<UserAuthEntity>
    {
        public UserAuthRepository(DataContext context) : base(context)
        {
        }

        internal void Update(UserAuthEntity userAuthEntity)
        {
            throw new NotImplementedException();
        }
    }

}

