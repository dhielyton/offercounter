using OfferCounter.Domain.Currencies;
using OfferCounter.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Infrastructure.Repositories
{
    public class CriptoCurrencyRepository : Repository<CriptoCurrency>, ICriptoCurrencyRepository
    {
        public CriptoCurrencyRepository(OfferCounterContex offerCounterContex) : base(offerCounterContex)
        {
        }
    }
}
