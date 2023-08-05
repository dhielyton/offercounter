using OfferCounter.Domain.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.Portfolios
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task DecreaseQuantity(string portfolioId, double quantity)
        {
            var portfolio = await _portfolioRepository.Get(portfolioId);

            if (portfolio == null)
                throw new PortfolioNotFoundException();

            portfolio.DecreaseQuantity(quantity);
            await _portfolioRepository.Update(portfolio);
        }

        public async Task IncreaseQuantity(string portfolioId, double quantity)
        {
            var portfolio = await _portfolioRepository.Get(portfolioId);

            if (portfolio == null)
                throw new PortfolioNotFoundException();

            portfolio.Increase(quantity);
            await _portfolioRepository.Update(portfolio);
        }
    }
}
