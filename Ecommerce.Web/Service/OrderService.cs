using Ecommerce.Web.Models;
using Ecommerce.Web.Service.IService;
using Ecommerce.Web.Utility;

namespace Ecommerce.Web.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
        }



        public async Task<Response?> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.OrderAPIBase + "/api/order/CreateOrder"
            });
        }

        public async Task<Response?> GetAllOrder(string? userId)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "/api/order/GetOrders?userId=" + userId
            });
        }

        public async Task<Response?> GetOrder(int orderId)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "/api/order/GetOrder/" + orderId
            });
        }

        public async Task<Response?> UpdateOrderStatus(int orderId, string newStatus)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = newStatus,
                Url = SD.OrderAPIBase + "/api/order/UpdateOrderStatus/" + orderId
            });
        }
    }
}
