

using AutoMapper;
using ClinicManager.Core.Common;
using ClinicManager.Core.DTO.User;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Enums;
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
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AuthService(UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IJwtTokenGenrator jwtTokenGenrator,
            IPatientService patientService,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtTokenGenrator = jwtTokenGenrator;
            _petientService = patientService;
            _roleManager = roleManager;
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

            var userFromDb = await _userManager.FindByEmailAsync(model.Email);

            if(userFromDb is not null)
            {
                return new AuthResult
                {
                    Success = false,
                    Message = $"This is email {model.Email} is already registred try to log in"
                };
            }

            var registerModel = _mapper.Map<RegisterModel>(model);

            var user = await CreateUserAsync(registerModel);

            if (user is not null)
            {
                await _userManager.AddToRoleAsync(user, enRole.Patient.ToString());
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
                    Message = "Register Succeded"
                    
                };



            }

            return new AuthResult
            {
                Success = false,
                Message = "Fild To Register"
            };
        }
    }
}
