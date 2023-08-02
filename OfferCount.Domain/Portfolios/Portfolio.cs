using OfferCount.Domain.Accounts;
using OfferCount.Domain.Currencies;

namespace OfferCount.Domain.Portfolios
{
    public class Portfolio
    {
        public Portfolio()
        {
            
        }
        public Portfolio( CriptoCurrency currency, double quantity, Account account)
        {
            Id = Guid.NewGuid().ToString();
            Currency = currency;
            Quantity = quantity;
            Account = account;
        }

        public string Id { get; private set; }
        public CriptoCurrency Currency { get; set; }
        public double Quantity { get; set; }
        public Account Account { get; set; }

        public void DecreaseQuantity(double quantity)
        {
            if(quantity > Quantity)
                throw new QuantityNotSufficentException();

            Quantity -= quantity;
        }
        
    }
}
