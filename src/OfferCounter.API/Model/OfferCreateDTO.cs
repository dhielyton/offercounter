using System.Runtime.Serialization;

namespace OfferCounter.API.Model
{
    public class OfferCreateDTO
    {

        [DataMember]
        public string PortfolioId { get; set; }
        [DataMember]
        public double UnitPrice { get;  set; }
        [DataMember]
        public double Quantity { get;  set; }
    }
}
