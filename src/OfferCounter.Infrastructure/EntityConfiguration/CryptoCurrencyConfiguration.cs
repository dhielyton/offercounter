using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferCounter.Domain.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Infrastructure.EntityConfiguration
{
    public class CryptoCurrencyConfiguration : IEntityTypeConfiguration<CriptoCurrency>
    {
        public void Configure(EntityTypeBuilder<CriptoCurrency> builder)
        {
            builder.ToTable(nameof(CriptoCurrency));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Abbreviation).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
