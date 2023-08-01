using OfferCount.Domain.Accounts;
using OfferCount.Domain.Currencies;

namespace OfferCount.Domain.Portfolios
{
    public class Portfolio
    {
        public string GUID { get; set; }
        public CriptoCurrency Currency { get; set; }
        public double Quantity { get; set; }
        public Account Account { get; set; }
        
    }
}
