using Ecommerce.Web.Models;
using Ecommerce.Web.Service.IService;

namespace Ecommerce.Web.Service
{
    public class BaseService : IBaseService
    {
        public Task<Response?> SendAsync(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
