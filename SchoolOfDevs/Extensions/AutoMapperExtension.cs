using AutoMapper;
using SchoolOfDevs.Dtos;
using SchoolOfDevs.Entities;

namespace SchoolOfDevs.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddRegisterAutoMapper(this IServiceCollection services)
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
        }
    }
}
