using OrderSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Core.Services.Contract
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetProductsAsync();

        Task<Product?> GetProductByIdAsync(int productId);

        Task<Product?> AddProductAsync(Product product);
        Task<Product?> UpdateProduct(Product product);
    }
}
