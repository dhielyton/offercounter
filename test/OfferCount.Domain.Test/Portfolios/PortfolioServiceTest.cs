using Moq;
using Newtonsoft.Json;
using OfferCounter.Domain.Portfolios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
namespace OfferCount.Domain.Test.Portfolios
{
    public class PortfolioServiceTest
    {
        private Mock<IPortfolioRepository> _portfolioRepository = new Mock<IPortfolioRepository>();
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
        public async Task DecreaseQuantitySucessfully()
        {
            var portfolioId = "5cd4719d-8c5f-40c7-9203-5d50afcec488";
            configureGetPortfolioRepository(_portfolioRepository, portfolioId);
            var portfolioService = new PortfolioService(_portfolioRepository.Object);
            await portfolioService.DecreaseQuantity(portfolioId, 5);

        }

        [Fact]
        public async Task IncreaseQuantitySucessfully()
        {
            var portfolioId = "5cd4719d-8c5f-40c7-9203-5d50afcec488";
            configureGetPortfolioRepository(_portfolioRepository, portfolioId);
            var portfolioService = new PortfolioService(_portfolioRepository.Object);
            await portfolioService.IncreaseQuantity(portfolioId, 5);

        }

        [Fact]
        public async Task DecreaseQuantityThrowsQuantityNotSufficentException()
        {
            var portfolioId = "fe6f81af-83d6-43e9-a53a-b03cc517cd6f";
            configureGetPortfolioRepository(_portfolioRepository, portfolioId);
            var portfolioService = new PortfolioService(_portfolioRepository.Object);
            Action action = () =>  portfolioService.DecreaseQuantity(portfolioId, 5).Wait();
            action.Should().Throw<QuantityNotSufficentException>();

        }
    }
}
