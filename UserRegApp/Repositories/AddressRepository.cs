using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegApp.Context;
using UserRegApp.Entities;

namespace UserRegApp.Repositories
{
    internal class AddressRepository : Repo<AddressEntity>
    {
        public AddressRepository(DataContext context) : base(context)
        {
        }
    }

}

