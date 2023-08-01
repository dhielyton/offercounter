﻿using FluentAssertions;
using OfferCount.Domain.Currencies;
using OfferCount.Domain.Offers;
using OfferCount.Domain.Portfolios;
using System;
using Xunit;

namespace OfferCount.Domain.Test.Offers
{
    public class OfferTest
    {

        [Fact]
        public void CreateOfferWithSucess()
        {
            var offer = new Offer(new Portfolio(), 1, 1);

            offer.Should().NotBeNull();
            offer.UnitPrice.Should().BeGreaterThan(0);
            offer.Quantity.Should().BeGreaterThan(0);
            offer.Portfolio.Should().NotBeNull();

        }

        [Fact]
        public void ProcessOfferWithSucess()
        {
            var offer = new Offer(new Portfolio(), 1, 1);
            offer.Process();
            offer.Should().NotBeNull();
            offer.Situation.Should().Be(Situation.PROCESSED);
        }

        [Fact]  
        public void ProcessOfferWithOfferCantBeProcessedException()
        {
            var offer = new Offer(new Portfolio(), 1, 1);
            offer.Process();
            Action action = () => offer.Process();
            action.Should().Throw<OfferCantBeProcessedException>();
        }

        [Fact]
        public void DeleteOfferWithSucess()
        {
            var offer = new Offer(new Portfolio(), 1, 1);
            offer.Process();
            offer.Delete();
            offer.Should().NotBeNull();
            offer.Situation.Should().Be(Situation.CANCELED);

        }

        [Fact]
        public void DeleteOfferWithOfferCantBeDeletedException()
        {
            var offer = new Offer(new Portfolio(), 1, 1);
            offer.Process();
            offer.Delete();
            Action action = () => offer.Delete();
            action.Should().Throw<OfferCantBeDeletedException>();
        }




    }
}
