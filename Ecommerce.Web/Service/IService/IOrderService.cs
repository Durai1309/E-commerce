using Ecommerce.Web.Models;

namespace Ecommerce.Web.Service.IService
{
    public interface IOrderService
    {
        Task<Response?> CreateOrder(CartDto cartDto);
        Task<Response?> GetAllOrder(string? userId);
        Task<Response?> GetOrder(int orderId);
        Task<Response?> UpdateOrderStatus(int orderId, string newStatus);
    }
}
