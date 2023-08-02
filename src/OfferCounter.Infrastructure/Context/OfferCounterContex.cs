using Microsoft.EntityFrameworkCore;
using OfferCounter.Domain.Accounts;
using OfferCounter.Domain.Currencies;
using OfferCounter.Domain.Offers;
using OfferCounter.Domain.Portfolios;
using OfferCounter.Domain.Users;
using OfferCounter.Infrastructure.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Infrastructure.Context
{
    public class OfferCounterContex: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CriptoCurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new PortfolioConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());

        }
        public DbSet<CriptoCurrency> CryptoCurrencies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Portfolio> Portfolios{ get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
