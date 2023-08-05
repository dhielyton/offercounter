using MediatR;
using OfferCounter.Domain.Portfolios;
using OfferCounter.Domain.SharedKernel;
using OfferCounter.Domain.Users;
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
        private IUserRepository _userRepository;
        public OfferService(IPortfolioRepository portfoliosRepository, IOfferRepository offerRepository, IUserRepository userRepository, IMediator mediator) : base(mediator)
        {
            _portfoliosRepository = portfoliosRepository;
            _offerRepository = offerRepository;
            _userRepository = userRepository;
        }

        public async Task<Offer> Create(string portfolioId, double quantity, double unitPrice, string userId)
        {
            var portfolio = await _portfoliosRepository.Get(portfolioId);

            if (portfolio == null)
                throw new PortfolioNotFoundException();

            if (portfolio.Account.UserId != userId)
                throw new PortfolioEnteredDoesntMatchWithUserException();

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
