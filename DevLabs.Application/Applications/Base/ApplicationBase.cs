using AutoMapper;
using DevLabs.Application.Interfaces.Base;
using DevLabs.Application.Structs;
using DevLabs.Domain.Core.Interfaces.Service.Base;
using DevLabs.Domain.Entitys.Base;
using DevLabs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevLabs.Application.Applications.Base
{
    public class ApplicationBase<TEntity, TView, TPost, TPut> :
        IApplicationBase<TEntity, TView, TPost, TPut>
        where TEntity : EntityBase where TView : class where TPost : class where TPut : class
    {
        protected readonly IMapper mapper;
        protected readonly IServiceBase<TEntity> serviceBase;

        public ApplicationBase(IServiceBase<TEntity> serviceBase, IMapper mapper)
        {
            this.serviceBase = serviceBase;
            this.mapper = mapper;
        }

        public virtual async Task<IEnumerable<TView>> GetAllAsync()
        {
            IEnumerable<TEntity> consulta = await serviceBase.GetAllAsync();
            return mapper.Map<IList<TView>>(consulta);
        }

        public virtual async Task<TView> GetByIdAsync(Guid id)
        {
            TEntity consulta = await serviceBase.GetByIdAsync(id);
            return mapper.Map<TView>(consulta);
        }

        public virtual async Task<EntityToDto<TEntity, TPut>> MapStructById(Guid id)
        {
            TEntity obj = await serviceBase.GetByIdAsync(id);
            return new EntityToDto<TEntity, TPut>(obj, mapper.Map<TPut>(obj));
        }

        public virtual async Task<TView> PostAsync(TPost post)
        {
            TEntity consulta = mapper.Map<TEntity>(post);
            consulta = await serviceBase.PostAsync(consulta);
            return mapper.Map<TView>(consulta);
        }

        public virtual async Task<TView> PutAsync(TPut put)
        {
            TEntity consulta = mapper.Map<TEntity>(put);
            consulta = await serviceBase.PutAsync(consulta);
            return mapper.Map<TView>(consulta);
        }

        public virtual async Task<TView> DeleteAsync(Guid id)
        {
            TEntity consulta = await serviceBase.DeleteAsync(id);
            return mapper.Map<TView>(consulta);
        }

        public async Task<TView> PutStatusAsync(Guid id, Status status)
        {
            TEntity consulta = await serviceBase.GetByIdAsync(id);
            if (consulta is null)
            {
                return null;
            }

            consulta.ChangeStatusValue((int)status);

            TEntity obj = await serviceBase.PutStatusAsync(consulta);
            return mapper.Map<TView>(obj);
        }

        public virtual async Task<bool> ExisteNaBaseAsync(Guid id)
        {
            return await serviceBase.ExisteNaBaseAsync(id);
        }

        public virtual async Task MapStructSaveChangesAsync(EntityToDto<TEntity, TPut> dtoStruct)
        {
            mapper.Map(dtoStruct.Dto, dtoStruct.Entity);
            await serviceBase.SaveChangesAsync();
        }
    }
}