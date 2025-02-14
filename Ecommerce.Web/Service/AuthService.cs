using Ecommerce.Web.Models;
using Ecommerce.Web.Service.IService;
using Ecommerce.Web.Utility;

namespace Ecommerce.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<Response?> AssignRoleAsync(RegistrationRequest registrationRequest)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequest,
                Url = SD.AuthAPIBase + "/api/auth/AssignRole"
            });
        }

        public Task<Response?> LoginAsync(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Response?> RegisterAsync(RegistrationRequest registrationRequest)
        {
            throw new NotImplementedException();
        }

        /*public async Task<Response?> LoginAsync(LoginRequest loginRequest)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequest,
                Url = SD.AuthAPIBase + "/api/auth/login"
            }, withBearer: false);

        }

        public async Task<Response?> RegisterAsync(RegistrationRequest registrationRequest)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequest,
                Url = SD.AuthAPIBase + "/api/auth/register"
            }, withBearer: false);
        }*/
    }
}