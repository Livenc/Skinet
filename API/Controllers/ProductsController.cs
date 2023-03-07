using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<Product> _productRepo;
        
        public ProductsController(IGenericRepository<Product> productrepo,
        IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo )
        {
            _productRepo = productrepo;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            
           
            
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productRepo.ListAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>>  GetProduct(int id)
        {
            return await _productRepo.GetByIdAsync(id);
        }

        // Поиск по од для бренда продукта

        // [HttpGet("brands/{id}")]
        // public async Task<ActionResult<ProductBrand>>  GetProductBrand(int id)
        // {
        //      return await _repo.GetProductBrandByIdAsync(id);
        //  }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
                return Ok(await _productBrandRepo.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
                return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}