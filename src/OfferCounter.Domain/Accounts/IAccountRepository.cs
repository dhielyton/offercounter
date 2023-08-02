using OfferCounter.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.Accounts
{
    public  interface IAccountRepository: IRepository<Account>
    {
    }
}
