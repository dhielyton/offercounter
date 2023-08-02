using FluentAssertions;
using OfferCounter.Domain.Accounts;
using OfferCounter.Domain.Currencies;
using OfferCounter.Domain.Portfolios;
using OfferCounter.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OfferCounter.Domain.Test.Portfolios
{
    public class PortfolioTest
    {


        [Fact]
        public void CreatePortfolioWithSucess()
        {
            var currency = new CriptoCurrency("BTC","BITCOIN");
            var account = new Account(new User("Test"));
            var portfolio = new Portfolio(currency, 0.10000, account);
            portfolio.Should().NotBeNull();
            portfolio.Currency.Should().NotBeNull();
            portfolio.Account.Should().NotBeNull();
            portfolio.Quantity.Should().Be(0.10000);


        }

        [Fact]
        public void DecreaseAmountWithSucess()
        {
            var currency = new CriptoCurrency("BTC", "BITCOIN");
            var account = new Account(new User("Test"));
            var portfolio = new Portfolio(currency, 0.10000, account);
            portfolio.DecreaseQuantity(0.000200);
            portfolio.Quantity.Should().Be(0.0998);

        }

        [Fact]
        public void DecreaseAmountThrowsQuantityNotSufficentException()
        {
            var currency = new CriptoCurrency("BTC", "BITCOIN");
            var account = new Account(new User("Test"));
            var portfolio = new Portfolio(currency, 0.10000, account);
            Action action = () => portfolio.DecreaseQuantity(5.000200);
            action.Should().Throw<QuantityNotSufficentException>();

        }

    }
}
