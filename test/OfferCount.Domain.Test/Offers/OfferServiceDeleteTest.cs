using FluentAssertions;
using MediatR;
using Moq;
using Newtonsoft.Json;
using OfferCounter.Domain.Offers;
using OfferCounter.Domain.Portfolios;
using OfferCounter.Domain.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OfferCount.Domain.Test.Offers
{
    public class OfferServiceDeleteTest : OfferServiceTestBase
    {
       

        public OfferService configureService(string offerId)
        {
            configureGetOffer(_offerRepository, offerId);
            return  new OfferService(new Mock<IPortfolioRepository>().Object, _offerRepository.Object, _userRepository.Object, mediator.Object);
        }




        [Fact]
        public void DeleteOfferWithSucessfully()
        {
            var offerId = "63dfe1a8-74d2-400e-bf6a-db1f10d4cfeb";
            var userId = "df7d23f2-af87-46b2-9ffc-0f035687e9a8";
            var offerService = configureService(offerId);
            offerService.Delete(offerId, userId);
        }

        [Fact]
        public void DeleteOfferThrowsOfferNotFoundException()
        {
            var offerId = "bbad7b49-e108-4c40-a95c-e317539bfe83";
            var userId = "df7d23f2-af87-46b2-9ffc-0f035687e9a8";

            var offerService = configureService(offerId);
            Action action = () => offerService.Delete(offerId, userId).Wait();
            action.Should().Throw<OfferNotFoundException>();
        }

        [Fact]
        public void DeleteOfferThrowsUserNotFoundException()
        {
            var offerId = "63dfe1a8-74d2-400e-bf6a-db1f10d4cfeb";
            var userId = "057f3445-8ad6-4929-b2ab-7bf9031d3a44";

            var offerService = configureService(offerId);
            Action action = () => offerService.Delete(offerId, userId).Wait();
            action.Should().Throw<UserNotFoundException>();
        }
    }
}
