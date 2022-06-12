using DevLabs.Domain.Core.Interfaces.Repositories.Base;
using DevLabs.Domain.Core.Interfaces.Service.Base;
using DevLabs.Domain.Entitys.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevLabs.Domain.Services.Base
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            this.repositoryBase = repositoryBase;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repositoryBase.GetAllAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await repositoryBase.GetByIdAsync(id);
        }

        public virtual async Task<TEntity> PostAsync(TEntity obj)
        {
            return await repositoryBase.PostAsync(obj);
        }

        public virtual async Task<TEntity> PutAsync(TEntity obj)
        {
            return await repositoryBase.PutAsync(obj);
        }

        public virtual async Task<TEntity> DeleteAsync(Guid id)
        {
            return await repositoryBase.DeleteAsync(id);
        }

        public async Task<TEntity> PutStatusAsync(TEntity obj)
        {
            return await repositoryBase.PutAsync(obj);
        }

        public virtual async Task<bool> ExisteNaBaseAsync(Guid id)
        {
            return await repositoryBase.ExisteNaBaseAsync(id);
        }

        public virtual async Task SaveChangesAsync()
        {
            await repositoryBase.SaveChangesAsync();
        }
    }
}