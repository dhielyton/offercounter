﻿using OfferCounter.Domain.Currencies;
using OfferCounter.Domain.Portfolios;

namespace OfferCounter.Domain.Offers
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
        public string PortfolioId { get; set; }
        public double UnitPrice { get; private set; }
        public double Quantity { get; private set; }
        public Situation Situation { get; private set; }

        public DateTime CrationDate { get; set; }

        public void Process()
        {
            if(Situation != Situation.OPEN)
                throw new OfferCantBeProcessedException();

            Situation = Situation.PROCESSED;
        }

        public void Delete()
        {
            if (Situation != Situation.PROCESSED)
                throw new OfferCantBeDeletedException();

            Situation = Situation.CANCELED;
        }
        


    }
}
