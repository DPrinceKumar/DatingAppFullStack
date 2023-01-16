using DatingAppFS.Entity;
using DatingAppFS.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DatingAppFS.Services
{
    public class TokenServices : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenServices(IConfiguration configuration) 
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.UserName)
              };

            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokern=tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(tokern);
        }
    }
}
