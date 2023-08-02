using OfferCounter.Domain.Offers;
using OfferCounter.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Infrastructure.Repositories
{
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {
        public OfferRepository(OfferCounterContex offerCounterContex) : base(offerCounterContex)
        {
        }
    }
}
