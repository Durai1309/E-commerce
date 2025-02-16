using Ecommerce.Web.Models;

namespace Ecommerce.Web.Service.IService
{
    public interface IProductService
    {
        Task<Response?> GetAllProductsAsync();
        Task<Response?> GetProductByIdAsync(int id);
        Task<Response?> CreateProductsAsync(ProductDto productDto);
        Task<Response?> UpdateProductsAsync(ProductDto productDto);
        Task<Response?> DeleteProductsAsync(int id);
    }
}
