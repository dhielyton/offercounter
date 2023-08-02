using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferCounter.Domain.Portfolios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Infrastructure.EntityConfiguration
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.ToTable(nameof(Portfolio));
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Address).IsRequired();

            builder.HasOne(x => x.Account)
                .WithMany()
                .HasForeignKey(x => x.AccountId);
            builder.HasOne(x => x.Currency)
                .WithMany()
                .HasForeignKey(x => x.CurrencyId);

        }
    }
}
