using Ecommerce.Web.Models;

namespace Ecommerce.Web.Service.IService
{
    public interface ICartService
    {
        Task<Response?> GetCartByUserIdAsnyc(string userId);
        Task<Response?> UpsertCartAsync(CartDto cartDto);
        Task<Response?> RemoveFromCartAsync(int cartDetailsId);
        Task<Response?> ApplyCouponAsync(CartDto cartDto);

    }
}
