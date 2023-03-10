using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context= context;
        }
       // Поиск по од для бренда продукта

       // public async Task<ProductBrand> GetProductBrandByIdAsync(int id)
        //{
       //    return await _context.ProductBrand.FindAsync(id);
      //  }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.ProductBrand)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandsAsync()
        {
            return await _context.ProductBrand.ToListAsync();
        }

       

        public async Task<IReadOnlyList<ProductType>> GetProductsTypesAsync()
         {
            return await _context.ProductType.ToListAsync();
         }
    }
 }