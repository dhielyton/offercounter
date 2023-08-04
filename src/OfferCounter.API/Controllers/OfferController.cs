using Microsoft.AspNetCore.Mvc;
using OfferCounter.API.Model;
using OfferCounter.Domain.Offers;

namespace OfferCounter.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfferController : Controller
    {

        [HttpPost]

        public async Task<IActionResult> Create(OfferCreateDTO dto, [FromServices] IOfferService offerService)
        {
            await offerService.Create(dto.PortfolioId, dto.Quantity, dto.UnitPrice);
            return Ok(dto);
        }

    }
}
