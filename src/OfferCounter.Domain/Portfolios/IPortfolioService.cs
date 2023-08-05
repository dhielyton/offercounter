using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.Portfolios
{
    public interface IPortfolioService
    {
        Task DecreaseQuantity(string portfolioId, double quantity);
        Task IncreaseQuantity(string portfolioId, double quantity);
    }
}
