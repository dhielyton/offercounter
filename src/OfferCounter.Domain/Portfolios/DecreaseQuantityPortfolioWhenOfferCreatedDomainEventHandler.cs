using MediatR;
using OfferCounter.Domain.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.Portfolios
{
    public class DecreaseQuantityPortfolioWhenOfferCreatedDomainEventHandler : INotificationHandler<OfferCreatedDomainEvent>
    {
        private readonly IPortfolioService _portfolioService;

        public DecreaseQuantityPortfolioWhenOfferCreatedDomainEventHandler(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task Handle(OfferCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _portfolioService.DecreaseQuantity(notification.Offer.PortfolioId, notification.Offer.Quantity);
        }
    }
}
