using UserRegApp.Context;
using UserRegApp.Entities;

namespace UserRegApp.Repositories
{
    internal class RoleRepository : Repo<RoleEntity>
    {
        public RoleRepository(DataContext context) : base(context)
        {
        }
    }

}

