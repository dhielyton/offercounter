using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.Offers
{
    public class OfferDeletedDomainEvent : INotification
    {
        public OfferDeletedDomainEvent(Offer offer)
        {
            Offer = offer;
        }

        public Offer Offer{ get; set; }
    }
}
