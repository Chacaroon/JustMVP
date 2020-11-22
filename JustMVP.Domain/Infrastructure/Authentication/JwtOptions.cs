using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JustMVP.Domain.Infrastructure.Authentication
{
    public class JwtOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Key { get; set; }

        public SymmetricSecurityKey IssuerSigningKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}
