using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.DAL.Entities;

namespace TestTask.DAL.Context.EntityConfigurations;

public class UserConfig: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.UserId).IsRequired().ValueGeneratedOnAdd();

        builder.Property(x => x.Login).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Password).HasMaxLength(50);
        builder.Property(x => x.FirstName).HasMaxLength(40);
        builder.Property(x => x.LastName).HasMaxLength(40);
        builder.Property(x => x.DateOfBirth).HasColumnType("DATE");
        builder.Property(x => x.Gender).HasMaxLength(1);
    }
}