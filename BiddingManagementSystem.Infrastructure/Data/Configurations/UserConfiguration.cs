using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BiddingManagementSystem.Domain.Aggregates.UserAggregate;
using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.OwnsOne(u => u.Address, a =>
            {
                a.Property(ad => ad.Street).IsRequired().HasMaxLength(100);
                a.Property(ad => ad.City).IsRequired().HasMaxLength(50);
                a.Property(ad => ad.State).IsRequired().HasMaxLength(50);
                a.Property(ad => ad.PostalCode).IsRequired().HasMaxLength(20);
                a.Property(ad => ad.Country).IsRequired().HasMaxLength(50);
            });

            builder.HasMany(u => u.Bids)
                   .WithOne(b => b.User)
                   .HasForeignKey(b => b.UserId);

            builder.HasMany(u => u.Roles)
                   .WithMany(r => r.Users)
                   .UsingEntity(j => j.ToTable("UserRoles"));
        }
    }
}
