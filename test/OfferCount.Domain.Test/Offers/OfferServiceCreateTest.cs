using FluentAssertions;
using OfferCounter.Domain.Offers;
using OfferCounter.Domain.Portfolios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Newtonsoft.Json;
using System.IO;
using MediatR;

namespace OfferCount.Domain.Test.Offers
{
    public class OfferServiceCreateTest
    {
        private Mock<IPortfolioRepository> _portfolioRepository = new Mock<IPortfolioRepository>();
        private Mock<IMediator> mediator = new Mock<IMediator>();
        public OfferServiceCreateTest()
        {

        }

        private void configureGetPortfolioRepository(Mock<IPortfolioRepository> mock, string portfolioId)
        {
            mock.Setup(x => x.Get(It.IsAny<string>())).Returns(() =>
            {
                using (StreamReader r = new StreamReader(@"Offers\Data\Portfolio.json"))
                {

                    var json = r.ReadToEnd();
                    var results = JsonConvert.DeserializeObject<List<Portfolio>>(json);
                    var result = results.Where(x => x.Id == portfolioId).FirstOrDefault();
                    return Task.FromResult(result);
                }
            });
        }

        [Fact]
        public async Task CreateOfferToCurrencyWithSucessfully()
        {
            var portfolioId = "5cd4719d-8c5f-40c7-9203-5d50afcec488";
            configureGetPortfolioRepository(_portfolioRepository, portfolioId);
            var offerRepository = new Mock<IOfferRepository>();
            var service = new OfferService(_portfolioRepository.Object, offerRepository.Object, mediator.Object);
            Offer offer = await service.Create(portfolioId, 1, 1);


        }

        [Fact]
        public async Task CreateOfferToCurrencyThrowsPortfolioNotFoundException()
        {
            var portfolioId = "302a80c7-0af3-4be2-8a2c-7b6f4101f0c4";
            configureGetPortfolioRepository(_portfolioRepository, portfolioId);
            var offerRepository = new Mock<IOfferRepository>();
            var service = new OfferService(_portfolioRepository.Object, offerRepository.Object, mediator.Object);
            Action action = () => service.Create(portfolioId, 1, 1).Wait();
            action.Should().Throw<PortfolioNotFoundException>();


        }

        [Fact]
        public async Task CreateOfferToCurrencyThrowsQuantityNotSufficentException()
        {
            var portfolioId = "fe6f81af-83d6-43e9-a53a-b03cc517cd6f";
            configureGetPortfolioRepository(_portfolioRepository, portfolioId);
            var offerRepository = new Mock<IOfferRepository>();
            var service = new OfferService(_portfolioRepository.Object, offerRepository.Object, mediator.Object);
            Action action = () => service.Create(portfolioId, 1, 1).Wait();

            action.Should().Throw<QuantityNotSufficentException>();


        }

       


    }
}
