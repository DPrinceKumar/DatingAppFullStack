using DatingAppFS.Data;
using DatingAppFS.Interfaces;
using DatingAppFS.Services;
using Microsoft.EntityFrameworkCore;

namespace DatingAppFS.Extension
{
    public static class AddApplicationService
    {
        public static IServiceCollection AddAppService(this IServiceCollection services,
            IConfiguration configuration)
        {
            //connecting to sql lite 
            services.AddDbContext<AppUserDataContext>(option => 
            {
                //type of database to be used which has been installed from nuget package manager 
                // provide the connection string 
                option.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();


            //JWT (Json Web Token)      token servive, class where that service is implemented
            services.AddScoped<ITokenService, TokenServices>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            return services;
        }
    }
}
