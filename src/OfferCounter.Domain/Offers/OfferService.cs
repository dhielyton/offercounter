using OfferCounter.Domain.Portfolios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.Offers
{
    public class OfferService
    {
        private IPortfolioRepository _portfoliosRepository;

        public OfferService(IPortfolioRepository portfoliosRepository)
        {
            _portfoliosRepository = portfoliosRepository;
        }

        public async Task<Offer> CreateOffer(string portfolioId, double quantity, double unitPrice)
        {
            var portfolio = await _portfoliosRepository.Get(portfolioId);

            if(portfolio == null)
                throw new PortfolioNotFoundException();

            if(portfolio.Quantity == 0)
                throw new QuantityNotSufficentException();

            var offer = new Offer(portfolio, unitPrice, quantity);
            offer.Process();
            return offer;

        }
    }
}
