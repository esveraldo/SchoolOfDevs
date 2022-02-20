using Microsoft.EntityFrameworkCore;
using SchoolOfDevs.Context;

namespace SchoolOfDevs.Extensions
{
    public static class ContextExtension
    {
        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));
        }
    }
}
