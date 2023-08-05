using MediatR;
using OfferCounter.Domain.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.Portfolios
{
    public class IncreaseQuantityPortfolioWhenOfferDeletedDomainEventHandler : INotificationHandler<OfferDeletedDomainEvent>
    {
        private readonly IPortfolioService _portfolioService;

        public IncreaseQuantityPortfolioWhenOfferDeletedDomainEventHandler(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task Handle(OfferDeletedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _portfolioService.IncreaseQuantity(notification.Offer.PortfolioId, notification.Offer.Quantity);
        }
    }
}
