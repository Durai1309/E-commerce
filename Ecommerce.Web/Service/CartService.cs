using Ecommerce.Web.Models;
using Ecommerce.Web.Service.IService;
using Ecommerce.Web.Utility;

namespace Ecommerce.Web.Service
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;
        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<Response?> ApplyCouponAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "/api/cart/ApplyCoupon"
            });
        }

        public async Task<Response?> EmailCart(CartDto cartDto)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "/api/cart/EmailCartRequest"
            });
        }

        public async Task<Response?> GetCartByUserIdAsnyc(string userId)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ShoppingCartAPIBase + "/api/cart/GetCart/" + userId
            });
        }


        public async Task<Response?> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDetailsId,
                Url = SD.ShoppingCartAPIBase + "/api/cart/RemoveCart"
            });
        }


        public async Task<Response?> UpsertCartAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "/api/cart/CartUpsert"
            });
        }
    }
}
