using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Core.Repository.Contract
{
    public interface IGenericRepository<T>
    {
         Task<IReadOnlyList<T>> GetAllAsync();

         Task<T?> GetByIdAsync(int id);

         Task AddAsync(T entity);

         void Update(T entity);
         void Delete(T entity);


    }
}
