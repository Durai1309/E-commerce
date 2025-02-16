using Ecommerce.Web.Models;
using Ecommerce.Web.Service.IService;
using Ecommerce.Web.Utility;

namespace Ecommerce.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<Response?> CreateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/product",
                ContentType = SD.ContentType.MultipartFormData
            });
        }

        public async Task<Response?> DeleteProductsAsync(int id)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<Response?> GetAllProductsAsync()
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/product"
            });
        }



        public async Task<Response?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<Response?> UpdateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/product",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}