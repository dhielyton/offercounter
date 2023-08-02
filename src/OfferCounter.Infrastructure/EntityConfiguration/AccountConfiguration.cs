using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferCounter.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Infrastructure.EntityConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(nameof(Account));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Deleted).IsRequired();
            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Account>(x => x.UserId);

        }
    }
}
