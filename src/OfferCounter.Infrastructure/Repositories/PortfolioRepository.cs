using Microsoft.EntityFrameworkCore;
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
        public Task<Portfolio> Get(string Id)
        {
            return _dbSet.Include(x => x.Account).Where(x => x.Id == Id && x.Deleted == false).FirstOrDefaultAsync();
        }
    }
}
