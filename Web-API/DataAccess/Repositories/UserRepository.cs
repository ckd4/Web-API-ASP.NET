using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Wrapper;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<Customer>, IUserRepository
    {
        public UserRepository(ShopperContext context)
            : base(context)
        {
        }

    }
}
