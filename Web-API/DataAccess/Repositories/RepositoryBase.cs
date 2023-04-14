using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ShopperContext RepositoryContext { get; set; }

        public RepositoryBase(ShopperContext repoContext)
        {
            RepositoryContext = repoContext;
        }
        public async Task<List<T>> FindAllByCondition(Expression<Func<T, bool>> expression) => await RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        public async Task<List<T>> FindAll() => await RepositoryContext.Set<T>().AsNoTracking().ToListAsync();
        public async Task Create(T entity) => await RepositoryContext.Set<T>().AddAsync(entity);
        public async Task Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public async Task Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

    }
}
