using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfferCounter.API.Model;
using OfferCounter.API.Service.User;
using OfferCounter.Domain.Offers;
using OfferCounter.Domain.Portfolios;
using OfferCounter.Infrastructure.Context;
using System.Net;

namespace OfferCounter.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : Controller
    {

        private readonly OfferCounterContex offerCounterContex;

        public PortfolioController(OfferCounterContex offerCounterContex)
        {
            this.offerCounterContex = offerCounterContex;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<Portfolio>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<Portfolio>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> All([FromServices] IUserService userService, [FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {

            var portfolios = offerCounterContex.Portfolios.Include(x => x.Currency).Include(x => x.Account).Where(x => x.Account.UserId == userService.GetUserId());

            var totalItems = await portfolios.LongCountAsync();

            var itemsOnPage = await portfolios
                .OrderBy(c => c.Id)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();


            var model = new PaginatedItemsViewModel<Portfolio>(pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }
    }
}
