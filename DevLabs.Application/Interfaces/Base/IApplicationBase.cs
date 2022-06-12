using DevLabs.Application.Structs;
using DevLabs.Domain.Entitys.Base;
using DevLabs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevLabs.Application.Interfaces.Base
{
    public interface IApplicationBase<TEntity, TView, TPost, TPut>
           where TView : class where TPost : class where TPut : class where TEntity : EntityBase
    {
        Task<IEnumerable<TView>> GetAllAsync();

        Task<TView> GetByIdAsync(Guid id);

        Task<EntityToDto<TEntity, TPut>> MapStructById(Guid id);

        Task<TView> PostAsync(TPost post);

        Task<TView> PutAsync(TPut put);

        Task<TView> DeleteAsync(Guid id);

        Task<TView> PutStatusAsync(Guid id, Status status);

        Task<bool> ExisteNaBaseAsync(Guid id);

        Task MapStructSaveChangesAsync(EntityToDto<TEntity, TPut> dtoStruct);
    }
}