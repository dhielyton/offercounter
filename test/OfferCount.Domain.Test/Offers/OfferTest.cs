using FluentAssertions;
using Newtonsoft.Json;
using OfferCounter.Domain.Currencies;
using OfferCounter.Domain.Offers;
using OfferCounter.Domain.Portfolios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace OfferCounter.Domain.Test.Offers
{
    public class OfferTest
    {

        public Portfolio GetPortfoilo(string portfolioId)
        {
            using (StreamReader r = new StreamReader(@"Offers\Data\Portfolio.json"))
            {

                var json = r.ReadToEnd();
                var results = JsonConvert.DeserializeObject<List<Portfolio>>(json);
                var result = results.Where(x => x.Id == portfolioId).FirstOrDefault();
                return result;
            }
        }
        [Fact]
        public void CreateOfferWithSucess()
        {
            var portfolio = GetPortfoilo("5cd4719d-8c5f-40c7-9203-5d50afcec488");
            var offer = new Offer(portfolio, 1, 1);

            offer.Should().NotBeNull();
            offer.UnitPrice.Should().BeGreaterThan(0);
            offer.Quantity.Should().BeGreaterThan(0);
            offer.Portfolio.Should().NotBeNull();
            offer.CreationDate.Should().NotBe(DateTime.MinValue);
        }

        [Fact]
        public void ProcessOfferWithSucess()
        {
            var portfolio = GetPortfoilo("5cd4719d-8c5f-40c7-9203-5d50afcec488");
            var offer = new Offer(portfolio, 1, 1);
            offer.Process();
            offer.Should().NotBeNull();
            offer.Situation.Should().Be(Situation.PROCESSED);
        }

        [Fact]  
        public void ProcessOfferThrowsOfferCantBeProcessedException()
        {
            var portfolio = GetPortfoilo("5cd4719d-8c5f-40c7-9203-5d50afcec488");
            var offer = new Offer(portfolio, 1, 1);
            offer.Process();
            Action action = () => offer.Process();
            action.Should().Throw<OfferCantBeProcessedException>();
        }

        [Fact]
        public void CancelOfferWithSucess()
        {
            var portfolio = GetPortfoilo("5cd4719d-8c5f-40c7-9203-5d50afcec488");
            var offer = new Offer(portfolio, 1, 1);
            offer.Process();
            offer.Cancel();
            offer.Should().NotBeNull();
            offer.Situation.Should().Be(Situation.CANCELED);

        }

        [Fact]
        public void CancelOfferThrowsOfferCantBeDeletedException()
        {
            var portfolio = GetPortfoilo("5cd4719d-8c5f-40c7-9203-5d50afcec488");
            var offer = new Offer(portfolio, 1, 1);
            offer.Process();
            offer.Cancel();
            Action action = () => offer.Cancel();
            action.Should().Throw<OfferCantBeDeletedException>();
        }




    }
}
