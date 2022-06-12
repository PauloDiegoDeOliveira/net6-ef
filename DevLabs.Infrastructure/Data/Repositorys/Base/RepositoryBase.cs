using DevLabs.Domain.Core.Interfaces.Repositories.Base;
using DevLabs.Domain.Entitys.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevLabs.Infrastructure.Data.Repositorys.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        private readonly AppDbContext appDbContext;

        public RepositoryBase(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await appDbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await appDbContext.Set<TEntity>()
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<TEntity> PostAsync(TEntity obj)
        {
            appDbContext.Set<TEntity>().Add(obj);
            await appDbContext.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<TEntity> PutAsync(TEntity obj)
        {
            appDbContext.Entry(obj).State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<TEntity> DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            if (obj != null)
            {
                appDbContext.Remove(obj);
                await appDbContext.SaveChangesAsync();
            }
            return obj;
        }

        public virtual async Task<bool> ExisteNaBaseAsync(Guid id)
        {
            return await appDbContext.Set<TEntity>().AnyAsync(x => x.Id == id);
        }

        public virtual async Task SaveChangesAsync()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}