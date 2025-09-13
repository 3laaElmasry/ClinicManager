

using System.Text.Json.Serialization;

namespace ClinicManager.Core.Common
{
    public class AuthResult
    {
        public string? AccessToken { get; set; }

        public bool Success { get; set; }

        [JsonIgnore]
        public string? RefreshToken { get; set; }

        public DateTime? AccessTokenExpiration { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }


        [JsonIgnore]
        public string Message = string.Empty;
    }

}
