using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.Currencies
{
    public class CriptoCurrency
    {
        public CriptoCurrency(string abbreviation, string name)
        {
            Abbreviation = abbreviation;
            Name = name;
        }

        public string Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }




    }
}
