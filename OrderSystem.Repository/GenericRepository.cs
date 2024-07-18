using Microsoft.EntityFrameworkCore;
using OrderSystem.Core.Repository.Contract;
using OrderSystem.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        private readonly OrderManagementDbContext _dbContext;

        public GenericRepository(OrderManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
            => await _dbContext.AddAsync(entity);

        public void Delete(T entity)
            => _dbContext.Remove(entity);

        public void Update(T entity)
            => _dbContext.Update(entity);  
    }
}
