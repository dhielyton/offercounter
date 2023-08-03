using FluentAssertions;
using OfferCounter.Domain.Offers;
using OfferCounter.Domain.Portfolios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using OfferCounter.Domain.Accounts;
using OfferCounter.Domain.Currencies;
using OfferCounter.Domain.Users;

namespace OfferCount.Domain.Test.Offers
{
    public class OfferServiceTest
    {

        [Fact]
        public async Task CreateOfferToCurrencyWithSucessfully()
        {
            var currency = new CriptoCurrency("BTC", "BITCOIN");
            var account = new Account(new User("Test"));
            var portfolio = new Portfolio(currency, 0.10000, account);
            var portfolioRepository = new Mock<IPortfolioRepository>();
            portfolioRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(() => Task.FromResult(portfolio));

            var service = new OfferService(portfolioRepository.Object);
            Offer offer = await service.CreateOffer("", 1, 1);

            offer.Should().NotBeNull();
            offer.UnitPrice.Should().BeGreaterThan(0);
            offer.Quantity.Should().BeGreaterThan(0);
            offer.Portfolio.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateOfferToCurrencyThrowsPortfolioNotFoundException()
        {
            var currency = new CriptoCurrency("BTC", "BITCOIN");
            var account = new Account(new User("Test"));
            var portfolio = new Portfolio(currency, 0.10000, account);
            var portfolioRepository = new Mock<IPortfolioRepository>();

            var service = new OfferService(portfolioRepository.Object);
            Action action = () =>  service.CreateOffer("", 1, 1).Wait();

            action.Should().Throw<PortfolioNotFoundException>();

            
        }

        [Fact]
        public async Task CreateOfferToCurrencyThrowsQuantityNotSufficentException()
        {
            var currency = new CriptoCurrency("BTC", "BITCOIN");
            var account = new Account(new User("Test"));
            var portfolio = new Portfolio(currency, 0, account);
            var portfolioRepository = new Mock<IPortfolioRepository>();
            portfolioRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(() => Task.FromResult(portfolio));

            var service = new OfferService(portfolioRepository.Object);
            Action action = () => service.CreateOffer("", 1, 1).Wait();

            action.Should().Throw<QuantityNotSufficentException>();


        }
    }
}
