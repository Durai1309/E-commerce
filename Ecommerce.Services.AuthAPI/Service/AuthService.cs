using Ecommerce.Services.AuthAPI.Models;
using Ecommerce.Services.AuthAPI.Service.IService;
using Ecommerce.Services.AuthAPI.Data;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {

        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext db, IJwtTokenGenerator jwtTokenGenerator,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public Task<bool> AssignRole(string email, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public Task<string> Register(RegistrationRequest registrationRequest)
        {
            throw new NotImplementedException();
        }
    }
}
