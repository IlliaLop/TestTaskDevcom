using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTask.DAL.Context;

namespace TestTask.DAL.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddTestTaskContext(this IServiceCollection services, IConfiguration configuration)
    {
        var testTaskDbConnectionString = "TestTaskDBConnection";
        var connectionsString = configuration.GetConnectionString(testTaskDbConnectionString);
        services.AddDbContext<TestTaskContext>(options =>
            options.UseSqlServer(
                connectionsString,
                opt => opt.MigrationsAssembly(typeof(TestTaskContext).Assembly.GetName().Name)));
    }
}