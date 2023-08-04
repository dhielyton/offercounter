using Microsoft.AspNetCore.Mvc;
using OfferCounter.API.Model;
using OfferCounter.API.Service.User;
using OfferCounter.Domain.Offers;

namespace OfferCounter.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfferController : Controller
    {

        [HttpPost]

        public async Task<IActionResult> Create(OfferCreateDTO dto, [FromServices] IOfferService offerService, [FromServices] IUserService userService)
        {
            var offer = await offerService.Create(dto.PortfolioId, dto.Quantity, dto.UnitPrice);
            return Ok(offer);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(string offerId, [FromServices] IOfferService offerService, [FromServices] IUserService userService)
        {
            await offerService.Delete(offerId);
            return Ok();
        }

    }
}
