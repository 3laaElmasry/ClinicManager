

using AutoMapper;
using ClinicManager.Core.Common;
using ClinicManager.Core.DTO.User;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Enums;
using ClinicManager.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IJwtTokenGenrator _jwtTokenGenrator;
        private readonly IPatientService _petientService;
        private readonly IDoctorService _doctorService;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthService(UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IJwtTokenGenrator jwtTokenGenrator,
            IPatientService patientService,
            RoleManager<ApplicationRole> roleManager,
            IDoctorService doctorService,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtTokenGenrator = jwtTokenGenrator;
            _petientService = patientService;
            _roleManager = roleManager;
            _doctorService = doctorService;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser?> CreateUserAsync(RegisterModel model)
        {
            var user = _mapper.Map<ApplicationUser>(model);

            var res = await _userManager.CreateAsync(user, model.Password);

            return (res.Succeeded == true) ? user : null;
        }

        public async Task<AuthResult> DoctorRegisterAsync(DoctorRegister model)
        {

            var userFromDb = await _userManager.FindByEmailAsync(model.Email);

            if (userFromDb is not null)
            {
                return new AuthResult
                {
                    Success = false,
                    Message = $"This email {model.Email} is already registred try to log in"
                };
            }

            var registerModel = _mapper.Map<RegisterModel>(model);

            var user = await CreateUserAsync(registerModel);

            if (user is not null)
            {
                await _userManager.AddToRoleAsync(user, enRole.Doctor.ToString());

                var Doctor = new Doctor
                {
                    LicenseNumber = model.LicenseNumber,
                    ApplicationUserId = user.Id

                };
                await _doctorService.AddAsync(Doctor);

                var authRes = await _jwtTokenGenrator.GenrateToken(user);

                authRes.Message = "Registerd Was Succeded";
                return authRes;



            }

            return new AuthResult
            {
                Success = false,
                Message = "Fild To Register"
            };
        }

        public async Task<AuthResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user is null)
            {
                return new AuthResult()
                {
                    Success = false,
                    Message = $"This Email {model.Email} is not Exist Try to Register"
                };
            }
            var res = await _signInManager.PasswordSignInAsync(
                    userName: user.UserName?? "",
                    password: model.Password,
                    isPersistent: model.RememberMe,
                    lockoutOnFailure: false
                );
            if(res.Succeeded is false)
            {
                return new AuthResult
                {
                    Success = false,
                    Message = "User Name Or Password is Invalid!"
                };
            }

            var authRes = await _jwtTokenGenrator.GenrateToken(user);
            authRes.Message = "Login Was Succeded";
            return authRes;

           
        }

        public Task<AuthResult> Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResult> PatinetRegisterAsync(PatientRegister model)
        {

            var userFromDb = await _userManager.FindByEmailAsync(model.Email);

            if (userFromDb is not null)
            {
                return new AuthResult
                {
                    Success = false,
                    Message = $"This email {model.Email} is already registred try to log in"
                };
            }

            var registerModel = _mapper.Map<RegisterModel>(model);

            var user = await CreateUserAsync(registerModel);

            if (user is not null)
            {
                await _userManager.AddToRoleAsync(user, enRole.Patient.ToString());

                var patient = new Patient
                {
                    InsuranceName = model.InsuranceName,
                    ApplicationUserId = user.Id

                };
                await _petientService.AddAsync(patient);

                var authRes = await _jwtTokenGenrator.GenrateToken(user);

                authRes.Message = "Registers Was Succeded";
                return authRes;
            }

            return new AuthResult
            {
                Success = false,
                Message = "Fild To Register"
            };
        }

        public async Task<AuthResult> RefreshTokenAync(string refreshToken)
        {
            var authRes = new AuthResult();
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens!.Any(r => r.Token == refreshToken));

            if(user is null)
            {
                authRes.Message = "Invalid Token";
                return authRes;
            }

            RefreshToken refreshTokenFromUser = user.RefreshTokens!.First();

            if (!refreshTokenFromUser.IsActive)
            {
                authRes.Message = "Inactive Token";
                return authRes;
            }

            refreshTokenFromUser.RevokeOn = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            authRes = await _jwtTokenGenrator.GenrateToken(user);
            authRes.Message = "Refresh Token Created Successfully";
            return authRes;
        }
    }
}
