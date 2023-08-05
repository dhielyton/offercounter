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
using OfferCounter.Domain.Users;

namespace OfferCount.Domain.Test.Offers
{
    public class OfferServiceCreateTest : OfferServiceTestBase
    {

        public OfferServiceCreateTest()
        {

        }

        public OfferService configureService(string portfolioId, string userId)
        {
            configureGetPortfolioRepository(_portfolioRepository, portfolioId);
            var offerRepository = new Mock<IOfferRepository>();
            return new OfferService(_portfolioRepository.Object, offerRepository.Object, _userRepository.Object, mediator.Object);

        }

        [Fact]
        public async Task CreateOfferToCurrencyWithSucessfully()
        {
            var portfolioId = "5cd4719d-8c5f-40c7-9203-5d50afcec488";
            var userId = "df7d23f2-af87-46b2-9ffc-0f035687e9a8";

            var service = configureService(portfolioId, userId);
            Offer offer = await service.Create(portfolioId, 1, 1, userId);


        }

        [Fact]
        public async Task CreateOfferToCurrencyThrowsPortfolioNotFoundException()
        {
            var portfolioId = "302a80c7-0af3-4be2-8a2c-7b6f4101f0c4";
            var userId = "df7d23f2-af87-46b2-9ffc-0f035687e9a8";

            var service = configureService(portfolioId, userId);
            Action action = () => service.Create(portfolioId, 1, 1, userId).Wait();
            action.Should().Throw<PortfolioNotFoundException>();


        }

        [Fact]
        public async Task CreateOfferToCurrencyThrowsQuantityNotSufficentException()
        {
            var portfolioId = "fe6f81af-83d6-43e9-a53a-b03cc517cd6f";
            var userId = "df7d23f2-af87-46b2-9ffc-0f035687e9a8";

            var service = configureService(portfolioId, userId);

            Action action = () => service.Create(portfolioId, 1, 1, userId).Wait();
            action.Should().Throw<QuantityNotSufficentException>();


        }

        [Fact]
        public async Task CreateOfferToCurrencyThrowsPortfolioEnteredDoesntMatchWithUserException()
        {
            var portfolioId = "fe6f81af-83d6-43e9-a53a-b03cc517cd6f";
            var userId = "2b765496-ec85-4551-8315-6620a5ffe34f";

            var service = configureService(portfolioId, userId); 
            Action action = () => service.Create(portfolioId, 1, 1, userId).Wait();

            action.Should().Throw<PortfolioEnteredDoesntMatchWithUserException>();


        }




    }
}
