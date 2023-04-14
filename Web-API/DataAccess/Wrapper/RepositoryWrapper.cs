using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using DataAccess.Interfaces;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ShopperContext _repoContext;

        private IUserRepository _customer;

        public IUserRepository Customer
        {
            get
            {
                if (this._customer == null)
                    this._customer = new UserRepository(this._repoContext);

                return this._customer;
            }
        }
        public RepositoryWrapper(ShopperContext context)
        {
            _repoContext = context;
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
