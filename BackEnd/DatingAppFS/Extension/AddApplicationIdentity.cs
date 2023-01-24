using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DatingAppFS.Extension
{
    public static class AddApplicationIdentity
    {
        public static IServiceCollection AddAppIdentity(this IServiceCollection services,
            IConfiguration config)
        {

            //authentication
          /*  services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding
                        .UTF8.GetBytes(configuration["TokenKey"])),
                        ValidateIssuer= false,
                        ValidateAudience = false
                    };
                });
*/
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding
                            .UTF8.GetBytes(config["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        
                    };
                });
            return services;
        }
    }
}
