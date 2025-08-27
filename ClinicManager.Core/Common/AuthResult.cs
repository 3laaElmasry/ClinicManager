

namespace ClinicManager.Core.Common
{
    public class AuthResult
    {
        public string Token { get; set; } = string.Empty;

        public bool Success { get; set; }

        public string Message = string.Empty;
    }

}
