using OfferCounter.Domain.Users;
using OfferCounter.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Infrastructure.Repositories
{
    public class UserRespository : Repository<User>, IUserRepository
    {
        public UserRespository(OfferCounterContex offerCounterContex) : base(offerCounterContex)
        {
        }
    }
}
