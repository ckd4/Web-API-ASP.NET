using System;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
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
