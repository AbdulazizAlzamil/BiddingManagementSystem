using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;

namespace BiddingManagementSystem.Infrastructure.Data.Configurations
{
    public class BidConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(b => b.BidDate)
                   .IsRequired();

            builder.Property(b => b.Status)
                   .IsRequired()
                   .HasConversion<string>();

            builder.HasOne(b => b.Tender)
                   .WithMany(t => t.Bids)
                   .HasForeignKey(b => b.TenderId);

            builder.HasOne(b => b.User)
                   .WithMany(u => u.Bids)
                   .HasForeignKey(b => b.UserId);

            builder.HasMany(b => b.Documents)
                   .WithOne(d => d.Bid)
                   .HasForeignKey(d => d.BidId);
        }
    }
}
