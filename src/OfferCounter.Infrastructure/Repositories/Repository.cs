using Microsoft.EntityFrameworkCore;
using OfferCounter.Domain.Accounts;
using OfferCounter.Domain.SharedKernel;
using OfferCounter.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> where TEntity : Entity
    {
        private DbContext _dbContext;
        private DbSet<TEntity> _dbSet;
        public Repository( OfferCounterContex offerCounterContex)
        {
            _dbContext = offerCounterContex;
            _dbSet = offerCounterContex.Set<TEntity>();
        }
        public async Task<TEntity> Delete(TEntity entity)
        {
            entity.Delete();
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public Task<TEntity> Get(string Id)
        {
            return _dbSet.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            entity.GenerateId();
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
