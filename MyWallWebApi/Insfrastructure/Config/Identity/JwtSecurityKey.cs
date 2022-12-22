using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyWallWebApi.Insfrastructure.Config.Identity
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
