using Ecommerce.Web.Models;

namespace Ecommerce.Web.Service.IService
{
    public interface IBaseService
    {
        Task<Response?> SendAsync(Request request, bool withBearer = true);

    }
}
