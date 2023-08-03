using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using OfferCounter.Domain.Offers;
using OfferCounter.Domain.Portfolios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OfferCount.Domain.Test.Offers
{
    public class OfferServiceDeleteTest
    {
        private Mock<IOfferRepository> _offerRepository = new Mock<IOfferRepository>();


        private void configureGetOffer(Mock<IOfferRepository> mock, string offerId)
        {
            mock.Setup(x => x.Get(It.IsAny<string>())).Returns(() =>
            {
                using (StreamReader r = new StreamReader(@"Offers\Data\Offers.json"))
                {

                    var json = r.ReadToEnd();
                    var results = JsonConvert.DeserializeObject<List<Offer>>(json);
                    var result = results.Where(x => x.Id == offerId).FirstOrDefault();
                    return Task.FromResult(result);
                }
            });
        }


        [Fact]
        public void DeleteOfferWithSucessfully()
        {
            var offerId = "63dfe1a8-74d2-400e-bf6a-db1f10d4cfeb";
            configureGetOffer(_offerRepository, offerId);
            var offerService = new OfferService(new Mock<IPortfolioRepository>().Object, _offerRepository.Object);
            offerService.Delete(offerId);
        }

        [Fact]
        public void DeleteOfferThrowsOfferNotFoundException()
        {
            var offerId = "bbad7b49-e108-4c40-a95c-e317539bfe83";
            configureGetOffer(_offerRepository, offerId);
            var offerService = new OfferService(new Mock<IPortfolioRepository>().Object, _offerRepository.Object);
            Action action = ()=> offerService.Delete(offerId).Wait();
            action.Should().Throw<OfferNotFoundException>();
        }
    }
}
