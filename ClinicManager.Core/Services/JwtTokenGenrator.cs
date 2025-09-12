

using ClinicManager.Core.Common;
using ClinicManager.Core.Entities;
using ClinicManager.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            var authRes = new AuthResult
            {
                AccessToken = accessToken,
                AccessTokenExpiration = exp,
            };

            if(user.RefreshTokens is not null && user.RefreshTokens.Any(r => r.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault()!;
                authRes.RefreshToken = activeRefreshToken.Token;
                authRes.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                RefreshToken refresToken = GetRefreshToken();
                authRes.RefreshToken = refresToken.Token;
                authRes.RefreshTokenExpiration = refresToken.ExpiresOn;

                user.RefreshTokens?.Add(refresToken);
                await _userManager.UpdateAsync(user);

            }

            return authRes;

        }

        public RefreshToken GetRefreshToken()
        {
            var randomNumber = new byte[32];

            RandomNumberGenerator.Fill(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(20),
                CreatedOn = DateTime.UtcNow,
            };

        }
    }
}
