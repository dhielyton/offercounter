using FluentAssertions;
using OfferCount.Domain.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OfferCount.Domain.Test.Currencies
{
    public class CriptoCurrencyTest
    {
        [Fact]
        public void CreatCriptCurrencyWithSucess()
        {
            var criptoCurrency = new CriptoCurrency("BTC", "BITCOIN");

            criptoCurrency.Should().NotBeNull();
            criptoCurrency.Abbreviation.Should().NotBeEmpty();
            criptoCurrency.Name.Should().NotBeEmpty();
        }
    }
}
