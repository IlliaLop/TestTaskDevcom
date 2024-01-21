using Microsoft.EntityFrameworkCore;
using TestTask.DAL.Context.EntityConfigurations;

namespace TestTask.DAL.Context;

public static class ModelBuilderExtensions
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
    }
}