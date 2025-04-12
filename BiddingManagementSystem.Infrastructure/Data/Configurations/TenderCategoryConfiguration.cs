using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;

namespace BiddingManagementSystem.Infrastructure.Data.Configurations
{
    public class TenderCategoryConfiguration : IEntityTypeConfiguration<TenderCategory>
    {
        public void Configure(EntityTypeBuilder<TenderCategory> builder)
        {
            //builder.ToTable("TenderCategories");

            builder.HasKey(tc => tc.Id);

            builder.Property(tc => tc.Name).IsRequired();
        }
    }
}

