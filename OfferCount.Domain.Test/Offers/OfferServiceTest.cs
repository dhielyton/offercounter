using FluentAssertions;
using OfferCount.Domain.Currencies;
using OfferCount.Domain.Offers;
using OfferCount.Domain.Portfolios;
using System;
using Xunit;

namespace OfferCount.Domain.Test.Offers
{
    public class OfferServiceTest
    {

        [Fact]
        public void CreateOfferWithSucess()
        {
            var offer = new Offer(new Portfolio(), 1,1);
          
            offer.Should().NotBeNull();
            offer.UnitPrice.Should().BeGreaterThan(0);
            offer.Quantity.Should().BeGreaterThan(0);
            offer.Portfolio.Should().NotBeNull();



        }

        [Fact]
        public void ProcessOfferWithSucess()
        {
             var offer = new Offer(new Portfolio(), 1, 1);
            

        }
    }
}
