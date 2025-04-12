using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate;

namespace BiddingManagementSystem.Infrastructure.Data.Configurations
{
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Comments).HasMaxLength(1000);
            builder.Property(e => e.TotalScore).IsRequired();

            builder.HasOne(e => e.Bid)
                   .WithOne(b => b.Evaluation)
                   .HasForeignKey<Evaluation>(e => e.BidId)
                   .IsRequired();

            builder.HasIndex(e => e.BidId).IsUnique();
        }
    }
}
