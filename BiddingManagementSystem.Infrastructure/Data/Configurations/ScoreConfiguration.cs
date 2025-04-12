using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate;
using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Infrastructure.Data.Configurations
{
    public class ScoreConfiguration : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Value)
                   .HasConversion(
                       v => v.Value,
                       v => new ScoreValue(v))
                   .IsRequired();

            builder.HasOne(s => s.EvaluationCriteria)
                   .WithMany(ec => ec.Scores)
                   .HasForeignKey(s => s.EvaluationCriteriaId);

            builder.HasOne(s => s.Evaluation)
                   .WithMany(e => e.Scores)
                   .HasForeignKey(s => s.EvaluationId);
        }
    }
}
