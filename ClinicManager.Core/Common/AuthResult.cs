

using System.Text.Json.Serialization;

namespace ClinicManager.Core.Common
{
    public class AuthResult
    {
        public string Token { get; set; } = string.Empty;

        public bool Success { get; set; }


        public DateTime ExpirationDate { get; set; }

        [JsonIgnore]
        public string Message = string.Empty;
    }

}
