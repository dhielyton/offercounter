using MediatR;
using OfferCounter.Domain.Portfolios;
using OfferCounter.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.Offers
{
    public class OfferService : Service, IOfferService
    {
        private IPortfolioRepository _portfoliosRepository;
        private IOfferRepository _offerRepository;

        public OfferService(IPortfolioRepository portfoliosRepository, IOfferRepository offerRepository, IMediator mediator):base(mediator)
        {
            _portfoliosRepository = portfoliosRepository;
            _offerRepository = offerRepository;
        }

        public async Task<Offer> Create(string portfolioId, double quantity, double unitPrice)
        {
            var portfolio = await _portfoliosRepository.Get(portfolioId);

            if (portfolio == null)
                throw new PortfolioNotFoundException();

            if (portfolio.Quantity == 0)
                throw new QuantityNotSufficentException();

            var offer = new Offer(portfolio, unitPrice, quantity);
            offer.Process();
            await _offerRepository.Insert(offer);

            Publish(new OfferCreatedDomainEvent(offer));

            return offer;
        }

        public async Task Delete(string offerId)
        {
            var offer = await _offerRepository.Get(offerId);
            if (offer == null)
                throw new OfferNotFoundException();
            offer.Cancel();
            await _offerRepository.Delete(offer);

            Publish(new OfferDeletedDomainEvent(offer));

        }
    }
}
