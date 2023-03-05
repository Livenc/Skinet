

using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product > GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductsBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductsTypesAsync();

         // Поиск по од для бренда продукта
         
        //Task <ProductBrand> GetProductBrandByIdAsync(int id);
    }
}