using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Wrapper;

namespace DataAccess.Interfaces
{
    public interface IUserRepository : IRepositoryBase<Customer>
    {
    }
}
