using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(long id);
        Task Create(Customer model);
        Task Update(Customer model);
        Task Delete(long id);
    }
}
