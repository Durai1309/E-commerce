using Ecommerce.Web.Models;
using System.Threading.Tasks;

namespace Ecommerce.Web.Service.IService
{
    public interface IAuthService
    {
        Task<Response?> LoginAsync(LoginRequest loginRequest);
        Task<Response?> RegisterAsync(RegistrationRequest registrationRequest);
        Task<Response?> AssignRoleAsync(RegistrationRequest registrationRequest);
    }
}
