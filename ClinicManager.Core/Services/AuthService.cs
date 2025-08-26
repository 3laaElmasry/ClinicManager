

using AutoMapper;
using ClinicManager.Core.Common;
using ClinicManager.Core.DTO.User;
using ClinicManager.Core.Entities;
using ClinicManager.Core.ServiceContracts;

using Microsoft.AspNetCore.Identity;

namespace ClinicManager.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IJwtTokenGenrator _jwtTokenGenrator;
        
        public AuthService(UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IJwtTokenGenrator jwtTokenGenrator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtTokenGenrator = jwtTokenGenrator;
        }

        public async Task<ApplicationUser?> CreateUserAsync(RegisterModel model)
        {
            var user = _mapper.Map<ApplicationUser>(model);

            var res = await _userManager.CreateAsync(user,model.Password);

            return user;
        }

        public Task<AuthResult> Login(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResult> PatinetRegister(RegisterPatient model)
        {
            var registerModel = _mapper.Map<RegisterModel>(model);

            var user = await CreateUserAsync(registerModel);

            if (user is not null)
            {
                var token = await _jwtTokenGenrator.GenrateToken(user);

                return new AuthResult
                {
                    Success = true,
                    Token = token,
                };



            }

            return new AuthResult
            {
                Success = false,
            };
        }
    }
}
