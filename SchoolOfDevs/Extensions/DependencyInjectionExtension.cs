using SchoolOfDevs.Repositories.Contracts;
using SchoolOfDevs.Repositories.Implementations;
using SchoolOfDevs.Services.Contracts;
using SchoolOfDevs.Services.Implementations;

namespace SchoolOfDevs.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddRegisterServices( this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            //Services
            services.AddScoped<IUserService, UserService>();

            //Singleton
            services.AddSingleton<IConfiguration>(configuration);
        }
    }
}
