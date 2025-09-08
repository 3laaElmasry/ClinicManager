

using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Core.Entities
{
    [Owned]
    public class RefreshToken
    {
        public string Token { get; set; } = string.Empty;

        public DateTime Expiration { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expiration;

        public DateTime CreatedOn { get; set; }

        public DateTime? RevokeOn { get; set; }

        public bool IsActive => RevokeOn is null && !IsExpired;

    }
}
