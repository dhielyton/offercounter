using OfferCounter.Domain.Portfolios;
using OfferCounter.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Infrastructure.Repositories
{
    public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(OfferCounterContex offerCounterContex) : base(offerCounterContex)
        {
        }
    }
}
