﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.SharedKernel
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> Insert(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(T entity);

        Task<T> Get(string Id);
    }
}
