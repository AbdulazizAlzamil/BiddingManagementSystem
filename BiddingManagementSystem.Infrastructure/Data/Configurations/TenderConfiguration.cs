using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using System.Reflection.Emit;

namespace BiddingManagementSystem.Infrastructure.Data.Configurations
{
    public class TenderConfiguration : IEntityTypeConfiguration<Tender>
    {
        public void Configure(EntityTypeBuilder<Tender> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Description).IsRequired().HasMaxLength(500);
            builder.OwnsOne(t => t.DateRange, dr =>
            {
                dr.Property(d => d.Start).IsRequired();
                dr.Property(d => d.End).IsRequired();
            });
            builder.OwnsOne(t => t.Budget, b =>
            {
                b.Property(m => m.Amount).IsRequired().HasColumnType("decimal(18,2)");
                b.Property(m => m.Currency).IsRequired().HasMaxLength(3);
            });
            builder.Property(t => t.EligibilityCriteria).IsRequired().HasMaxLength(1000);
            builder.Property(t => t.Status).IsRequired().HasConversion<string>();

            builder.HasMany(t => t.Categories)
                   .WithOne(c => c.Tender)
                   .HasForeignKey(c => c.TenderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.Bids)
                   .WithOne(b => b.Tender)
                   .HasForeignKey(b => b.TenderId);

            builder.HasMany(t => t.Documents)
                   .WithOne(d => d.Tender)
                   .HasForeignKey(d => d.TenderId);

            builder.HasOne(t => t.User)
                   .WithMany(u => u.Tenders)
                   .HasForeignKey(t => t.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.WinningBid)
                   .WithMany()
                   .HasForeignKey(t => t.WinningBidId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
