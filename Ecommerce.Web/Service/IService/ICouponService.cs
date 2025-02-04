using Ecommerce.Web.Models;

namespace Ecommerce.Web.Service.IService
{
    public interface ICouponService
    {
        Task<Response?> GetCouponAsync(string couponCode);
        Task<Response?> GetAllCouponsAsync();
        Task<Response?> GetCouponByIdAsync(int id);
        Task<Response?> CreateCouponsAsync(Coupon couponDto);
        Task<Response?> UpdateCouponsAsync(Coupon couponDto);
        Task<Response?> DeleteCouponsAsync(int id);
    }
}