using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.APIs.DTOs;
using OrderSystem.Core.Entities;
using OrderSystem.Core.Services.Contract;

namespace OrderSystem.APIs.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        //  Get all products
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var products = await _productService.GetProductsAsync();

            var mappedProducts = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(mappedProducts);
        }


        // Get details of a specific product
        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null)
                return NotFound();

            return Ok(_mapper.Map<Product, ProductToReturnDto>(product));
        }


        // Add a new product (admin only)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProductToReturnDto>> AddNewProduct(ProductDto productDto)
        {
            var mappedProduct = _mapper.Map<ProductDto, Product>(productDto);

            var product = await _productService.AddProductAsync(mappedProduct);

            if(product == null)
                return BadRequest();

            return Ok(_mapper.Map<Product, ProductToReturnDto>(product));
        }



        // Update product details (admin only)
        [HttpPost("{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateProduct([FromRoute]int productId, [FromBody]Product product)
        {
            if(productId != product.ProductId)
                return BadRequest();

            var productResult = await _productService.GetProductByIdAsync(productId);

            if (product is null)
                return NotFound();

            var result = await _productService.UpdateProduct(product);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }
    }
}
