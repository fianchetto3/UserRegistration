using UserRegApp.Context;
using UserRegApp.Entities;

namespace UserRegApp.Repositories
{
    internal class UserRepository : Repo<UserEntity>
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        internal UserEntity Update(UserEntity userEntity)
        {
            throw new NotImplementedException();
        }
    }

}

