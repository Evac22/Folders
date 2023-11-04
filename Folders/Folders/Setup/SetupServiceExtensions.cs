using Folders.Context;
using Microsoft.EntityFrameworkCore;

namespace Folders.Setup
{
    public static class SetupServiceExtensions
    {
        public static IServiceCollection AddSetupServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });


            return services;
        }
    }
}
