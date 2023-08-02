using Microsoft.EntityFrameworkCore;
using OfferCounter.Domain.Accounts;
using OfferCounter.Domain.SharedKernel;
using OfferCounter.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Infrastructure.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(OfferCounterContex offerCounterContex) : base(offerCounterContex)
        {

        }
    }
}
