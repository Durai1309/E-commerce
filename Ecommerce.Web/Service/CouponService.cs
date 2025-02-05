using Ecommerce.Web.Models;
using Ecommerce.Web.Service.IService;

namespace Ecommerce.Web.Service
{
    public class CouponService : ICouponService
    {
        public Task<Response?> CreateCouponsAsync(Coupon couponDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response?> DeleteCouponsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response?> GetAllCouponsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response?> GetCouponAsync(string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task<Response?> GetCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response?> UpdateCouponsAsync(Coupon couponDto)
        {
            throw new NotImplementedException();
        }
    }
}
