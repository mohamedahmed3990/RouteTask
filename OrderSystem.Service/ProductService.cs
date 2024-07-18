using OrderSystem.Core;
using OrderSystem.Core.Entities;
using OrderSystem.Core.Repository.Contract;
using OrderSystem.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product?> AddProductAsync(Product product)
        {
            await _unitOfWork.Repository<Product>().AddAsync(product);
            var result = await _unitOfWork.CompleteAsync();

            if (result <= 0)
                return null;

            return product;
            
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(productId);
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var products = await _unitOfWork.Repository<Product>().GetAllAsync();
            return products;
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
             _unitOfWork.Repository<Product>().Update(product);
            var result = await _unitOfWork.CompleteAsync();
            if (result <= 0)
                return null;
            return product;
        }
    }
}
