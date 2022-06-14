using DevLabs.Domain.Core.Interfaces.Repositories;
using DevLabs.Domain.Core.Interfaces.Service;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using DevLabs.Domain.Services.Base;
using System;
using System.Threading.Tasks;

namespace DevLabs.Domain.Services
{
    public class ServiceProjeto : ServiceBase<Projeto>, IServiceProjeto
    {
        private readonly IRepositoryProjeto repositoryProjeto;

        public ServiceProjeto(IRepositoryProjeto repositoryProjeto) : base(repositoryProjeto)
        {
            this.repositoryProjeto = repositoryProjeto;
        }

        public async Task<PagedList<Projeto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            return await repositoryProjeto.GetPaginationAsync(parametersPalavraChave);
        }

        public async Task<Projeto> GetByIdDetailsAsync(Guid id)
        {
            return await repositoryProjeto.GetByIdDetailsAsync(id);
        }

        public bool ValidateIdProjectPut(Guid id)
        {
            return repositoryProjeto.ValidateIdProjectPut(id);
        }

        public bool ValidateNamePost(Projeto projeto)
        {
            return repositoryProjeto.ValidateNamePost(projeto);
        }

        public bool ValidateNamePut(Projeto projeto)
        {
            return repositoryProjeto.ValidateNamePut(projeto);
        }

        public bool ValidateIdURLHomologacaoPut(Guid id)
        {
            return repositoryProjeto.ValidateIdURLHomologacaoPut(id);
        }

        public bool ValidateIdURLProducaoPut(Guid id)
        {
            return repositoryProjeto.ValidateIdURLProducaoPut(id);
        }

        public bool ValidateIdURLDocumentacaoPut(Guid id)
        {
            return repositoryProjeto.ValidateIdURLDocumentacaoPut(id);
        }

        public bool ValidateIdContaPut(Guid id)
        {
            return repositoryProjeto.ValidateIdContaPut(id);
        }
    }
}