using Microsoft.EntityFrameworkCore;
using TestTask.DAL.Entities;

namespace TestTask.DAL.Context;

public class TestTaskContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Order> Orders => Set<Order>();
    
    public TestTaskContext(DbContextOptions<TestTaskContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Configure();
    }
}