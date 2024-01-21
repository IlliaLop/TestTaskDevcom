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
        
        var users = new List<User>
        {
            new User {UserId = 1, Login = "user1", Password = "password1", FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 1, 1), Gender = 'M' },
            new User {UserId = 2, Login = "user2", Password = "password2", FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1992, 5, 10), Gender = 'F' },
            new User {UserId = 3, Login = "user3", Password = "password3", FirstName = "Mike", LastName = "Johnson", DateOfBirth = new DateTime(1988, 8, 20), Gender = 'M' },
            new User {UserId = 4, Login = "user4", Password = "password4", FirstName = "Emily", LastName = "Brown", DateOfBirth = new DateTime(1995, 11, 15), Gender = 'F' },
            new User {UserId = 5, Login = "user5", Password = "password5", FirstName = "Alex", LastName = "Miller", DateOfBirth = new DateTime(1990, 2, 28), Gender = 'M' },
            new User {UserId = 6, Login = "user6", Password = "password6", FirstName = "Eva", LastName = "Davis", DateOfBirth = new DateTime(1987, 7, 12), Gender = 'F' },
            new User {UserId = 7, Login = "user7", Password = "password7", FirstName = "Daniel", LastName = "Clark", DateOfBirth = new DateTime(1993, 9, 5), Gender = 'M' }
        };

        var orders = new List<Order>
        {
            new Order { OrderId = 1, UserId = 1, OrderDate = DateTime.Now, OrderCost = 100.0M, ItemsDescription = "Description 1", ShippingAddress = "Address 1" },
            new Order { OrderId = 2, UserId = 2, OrderDate = DateTime.Now, OrderCost = 150.0M, ItemsDescription = "Description 2", ShippingAddress = "Address 2" },
            new Order { OrderId = 3, UserId = 3, OrderDate = DateTime.Now, OrderCost = 120.0M, ItemsDescription = "Description 3", ShippingAddress = "Address 3" },
            new Order { OrderId = 4, UserId = 4, OrderDate = DateTime.Now, OrderCost = 200.0M, ItemsDescription = "Description 4", ShippingAddress = "Address 4" },
            new Order { OrderId = 5, UserId = 5, OrderDate = DateTime.Now, OrderCost = 90.0M, ItemsDescription = "Description 5", ShippingAddress = "Address 5" },
            new Order { OrderId = 6, UserId = 6, OrderDate = DateTime.Now, OrderCost = 180.0M, ItemsDescription = "Description 6", ShippingAddress = "Address 6" },
            new Order { OrderId = 7, UserId = 7, OrderDate = DateTime.Now, OrderCost = 130.0M, ItemsDescription = "Description 7", ShippingAddress = "Address 7" }
        };

        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Order>().HasData(orders);

        base.OnModelCreating(modelBuilder);
    }
}