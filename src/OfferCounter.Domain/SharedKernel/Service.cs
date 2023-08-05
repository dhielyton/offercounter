using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.SharedKernel
{
    public abstract class Service
    {
        private IMediator mediator;

        protected Service(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Publish(INotification notification)
        {
            mediator.Publish(notification);
        }
    }
}
