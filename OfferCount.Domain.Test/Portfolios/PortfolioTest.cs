using FluentAssertions;
using OfferCount.Domain.Accounts;
using OfferCount.Domain.Currencies;
using OfferCount.Domain.Portfolios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OfferCount.Domain.Test.Portfolios
{
    public class PortfolioTest
    {


        [Fact]
        public void CreatePortfolioWithSucess()
        {
            var currency = new CriptoCurrency();
            var account = new Account();
            var portfolio = new Portfolio(currency, 0.10000, account);
            portfolio.Should().NotBeNull();
            portfolio.Currency.Should().NotBeNull();
            portfolio.Account.Should().NotBeNull();
            portfolio.Quantity.Should().Be(0.10000);


        }

        [Fact]
        public void DecreaseAmountWithSucess()
        {
            var currency = new CriptoCurrency();
            var account = new Account();
            var portfolio = new Portfolio(currency, 0.10000, account);
            portfolio.DecreaseAmount(0.000200);
            portfolio.Quantity.Should().Be(0.0998);



        }
             
    }
}
