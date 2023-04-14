using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Customer>> GetAll()
        {
            return await repositoryWrapper.Customer.FindAll();
        }
        public async Task<Customer> GetById(long id)
        {
            var user = await repositoryWrapper.Customer.FindAllByCondition(x => x.CustomerId == id);
            return user.First();
        }
        public async Task Create(Customer model)
        {
            await repositoryWrapper.Customer.Create(model);
            await repositoryWrapper.Save();
        }
        public async Task Update(Customer model)
        {
            await repositoryWrapper.Customer.Update(model);
            await repositoryWrapper.Save();
        }
        public async Task Delete(long id)
        {
            var user = await repositoryWrapper.Customer.FindAllByCondition(x => x.CustomerId == id);
            await repositoryWrapper.Customer.Delete(user.First());
            await repositoryWrapper.Save();
        }
    }
}
