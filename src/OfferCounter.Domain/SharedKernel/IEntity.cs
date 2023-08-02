using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.SharedKernel
{
    public interface IEntity
    {
        string Id { get; }
        public bool Deleted { get; set; }
    }
}
