using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfferCounter.API.Model;
using OfferCounter.API.Service.User;
using OfferCounter.Domain.Offers;
using OfferCounter.Infrastructure.Context;
using System.Net;

namespace OfferCounter.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class OfferController : Controller
    {

        private readonly OfferCounterContex offerCounterContex;

        public OfferController(OfferCounterContex offerCounterContex)
        {
            this.offerCounterContex = offerCounterContex;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]OfferCreateDTO dto, [FromServices] IOfferService offerService, [FromServices] IUserService userService)
        {
         
            var offer = await offerService.Create(dto.PortfolioId, dto.Quantity, dto.UnitPrice, userService.GetUserId());
            return Ok(offer);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(string offerId, [FromServices] IOfferService offerService, [FromServices] IUserService userService)
        {
            await offerService.Delete(offerId, userService.GetUserId());
            return Ok();
        }

        [HttpGet]
        [Route("AllByToday")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<Offer>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<Offer>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AllByDay([FromServices]IUserService userService,[FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {

            var offers = offerCounterContex.Offers.Where(x => x.CreationDate.Date == DateTime.Today.Date && x.UserId == userService.GetUserId());

            var totalItems = await offers.LongCountAsync();

            var itemsOnPage = await offers
                .OrderByDescending(c => c.CreationDate)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();
           

            var model = new PaginatedItemsViewModel<Offer>(pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

    }
}
