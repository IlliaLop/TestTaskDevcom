using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.DAL.Entities;

namespace TestTask.DAL.Context.EntityConfigurations;

public class UserConfig: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.UserId);
        builder.HasIndex(u => u.Login).IsUnique(); // User Login Should be unique
        builder.Property(x => x.UserId).IsRequired().ValueGeneratedOnAdd();

        builder.Property(x => x.Login).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Password).HasMaxLength(50);
        builder.Property(x => x.FirstName).HasMaxLength(40);
        builder.Property(x => x.LastName).HasMaxLength(40);
        builder.Property(x => x.DateOfBirth).HasColumnType("DATE");
        builder.Property(x => x.Gender).HasMaxLength(1);

        builder.HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);  // Do not allow to remove user if he has any order assigned

    }
}