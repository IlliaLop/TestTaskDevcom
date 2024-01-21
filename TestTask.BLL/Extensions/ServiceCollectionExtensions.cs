using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TestTask.BLL.MappingProfiles;

namespace TestTask.BLL.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new OrderProfile());
            cfg.AddProfile(new UserProfile());
        });

        var mapper = new Mapper(mapperConfig);

        services.AddSingleton<IMapper>(mapper);
    }
}