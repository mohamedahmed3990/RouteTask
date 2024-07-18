using OrderSystem.Core;
using OrderSystem.Core.Repository.Contract;
using OrderSystem.Repository.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderManagementDbContext _dbContext;
        private Hashtable _repositories;

        public UnitOfWork(OrderManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Hashtable();
        }
        public IGenericRepository<T> Repository<T>() where T : class
        {
            var key = typeof(T).Name;

            if(!_repositories.ContainsKey(key) )
            {
                var repository = new GenericRepository<T>(_dbContext);
                _repositories.Add(key, repository);
            }

            return _repositories[key] as IGenericRepository<T>;

        }
        public async Task<int> CompleteAsync()
            => await _dbContext.SaveChangesAsync();

        public async ValueTask DisposeAsync()
            => await _dbContext.DisposeAsync();

        
    }
}
