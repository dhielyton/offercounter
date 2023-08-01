using OfferCount.Domain.Currencies;
using OfferCount.Domain.Portfolios;

namespace OfferCount.Domain.Offers
{
    public class Offer
    {

        public Offer(Portfolio portfolio, double unitPrice, double quantity)
        {
            Id = Guid.NewGuid().ToString();
            Portfolio = portfolio;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Situation = Situation.OPEN;
        }
        public string Id { get; set; }
        public Portfolio Portfolio { get; private set; }
        public double UnitPrice { get; private set; }
        public double Quantity { get; private set; }
        public Situation Situation { get; private set; }

        public void Process()
        {
            if(Situation != Situation.OPEN)
                throw new OfferCantBeProcessedException();

            Situation = Situation.PROCESSED;
        }
        


    }
}
