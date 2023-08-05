using OfferCounter.Domain.Accounts;
using OfferCounter.Domain.Currencies;
using OfferCounter.Domain.SharedKernel;

namespace OfferCounter.Domain.Portfolios
{
    public class Portfolio:Entity
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

        
        public string Address { get; set; }
        public CriptoCurrency Currency { get; set; }
        public string CurrencyId { get; set; }
        public double Quantity { get; set; }
        public Account Account { get; set; }
        public string AccountId { get; set; }

        public void DecreaseQuantity(double quantity)
        {
            if(quantity > Quantity)
                throw new QuantityNotSufficentException();

            Quantity -= quantity;
        }

        public void Increase(double quantity)
        {
            Quantity += quantity;
        }
        
    }
}
