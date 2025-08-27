

using AutoMapper;
using ClinicManager.Core.Common;
using ClinicManager.Core.DTO.User;
using ClinicManager.Core.Entities;
using ClinicManager.Core.ServiceContracts;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;

namespace ClinicManager.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IJwtTokenGenrator _jwtTokenGenrator;
        private readonly IPatientService _petientService;
        
        public AuthService(UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IJwtTokenGenrator jwtTokenGenrator,
            IPatientService patientService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtTokenGenrator = jwtTokenGenrator;
            _petientService = patientService;
        }

        public async Task<ApplicationUser?> CreateUserAsync(RegisterModel model)
        {
            var user = _mapper.Map<ApplicationUser>(model);

            var res = await _userManager.CreateAsync(user,model.Password);

            return (res.Succeeded == true) ? user : null;
        }

        public Task<AuthResult> Login(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResult> PatinetRegisterAsync(RegisterPatient model)
        {
            var registerModel = _mapper.Map<RegisterModel>(model);

            var user = await CreateUserAsync(registerModel);

            if (user is not null)
            {
                var token = await _jwtTokenGenrator.GenrateToken(user);

                var patient = new Patient
                {
                    InsuranceName = model.InsuranceName,
                    ApplicationUserId = user.Id

                };
                await _petientService.AddAsync(patient);

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
