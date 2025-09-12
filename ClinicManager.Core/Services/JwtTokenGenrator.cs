

using ClinicManager.Core.Common;
using ClinicManager.Core.Entities;
using ClinicManager.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicManager.Core.Services
{
    public class JwtTokenGenrator : IJwtTokenGenrator
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenrator(IOptions<JwtSettings> jwtSettings,UserManager<ApplicationUser> userManager)
        {
            _jwtSettings = jwtSettings.Value;
            _userManager = userManager;
        }
        public async Task<AuthResult> GenrateToken(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.FullName),
                new Claim(ClaimTypes.Role, userRoles.FirstOrDefault()?? "patient")
            };

            var exp = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: exp,
                    signingCredentials : cred
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);


            return new AuthResult()
            {
                Token = tokenString,
                ExpirationDate = exp,
                Success = true
            };
        }
    }
}
