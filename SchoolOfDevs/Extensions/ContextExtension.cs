using Microsoft.EntityFrameworkCore;
using SchoolOfDevs.Context;

namespace SchoolOfDevs.Extensions
{
    public static class ContextExtension
    {
        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            services.AddDbContextPool<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddDbContext<ApplicationDbContext>();
        }
    }
}
