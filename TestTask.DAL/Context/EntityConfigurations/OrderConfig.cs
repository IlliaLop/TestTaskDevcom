using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.DAL.Entities;

namespace TestTask.DAL.Context.EntityConfigurations;

public class OrderConfig: IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.OrderId);
        builder.Property(x => x.OrderId).IsRequired().ValueGeneratedOnAdd();

        builder.Property(x => x.UserId).IsRequired();

        builder.Property(x => x.OrderDate).IsRequired().HasColumnType("datetime2");  
        builder.Property(x => x.OrderCost).IsRequired().HasColumnType("MONEY");
    
        builder.Property(x => x.ItemsDescription).HasMaxLength(1000);
        builder.Property(x => x.ShippingAddress).HasMaxLength(1000);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}