namespace OfferCounter.API.Model
{
    public class OfferCreateDTO
    {
        public string PortfolioId { get; set; }
        public double UnitPrice { get; private set; }
        public double Quantity { get; private set; }
    }
}
