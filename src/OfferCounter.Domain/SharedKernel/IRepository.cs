using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.SharedKernel
{
    public interface IRepository<T>: IEntity
    {
        T Insert(IEntity entity);

        T Update(IEntity entity);

        T Delete(IEntity entity);

        T Get(string Id);
    }
}
