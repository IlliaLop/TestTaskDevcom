using TestTask.BLL.Interfaces;
using TestTask.BLL.Services;
using TestTask.DAL.Entities;

namespace TestTask.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IOrderService, OrderService>();
    }
}