using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferCounter.Domain.Offers;

namespace OfferCounter.Infrastructure.EntityConfiguration
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable(nameof(Offer));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.UnitPrice);
            builder.Property(x => x.PortfolioId).IsRequired();
            builder.Property(x => x.Situation).IsRequired();
            builder.Property(x => x.CrationDate).IsRequired();
            builder.HasOne(x => x.Portfolio)
                .WithMany()
                .HasForeignKey(x => x.PortfolioId);

        }
    }
}
