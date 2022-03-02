using System.Text.Json.Serialization;

namespace SchoolOfDevs.Extensions
{
    public static class ControllersExtension
    {
        public static void AddJson(this IServiceCollection services)
        {
            //services.AddControllers()
            //.AddNewtonsoftJson(opt =>
            //{
            //    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //});

            services.AddControllers()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            }
    }
}
