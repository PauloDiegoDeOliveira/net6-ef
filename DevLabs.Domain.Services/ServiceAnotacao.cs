using DevLabs.Domain.Core.Interfaces.Repositories;
using DevLabs.Domain.Core.Interfaces.Service;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using DevLabs.Domain.Services.Base;
using System;
using System.Threading.Tasks;

namespace DevLabs.Domain.Services
{
    public class ServiceAnotacao : ServiceBase<Anotacao>, IServiceAnotacao
    {
        private readonly IRepositoryAnotacao repositoryAnotacao;

        public ServiceAnotacao(IRepositoryAnotacao repositoryAnotacao) : base(repositoryAnotacao)
        {
            this.repositoryAnotacao = repositoryAnotacao;
        }

        public async Task<PagedList<Anotacao>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            return await repositoryAnotacao.GetPaginationAsync(parametersPalavraChave);
        }

        public bool ValidateIdAnotacaoPut(Guid id)
        {
            return repositoryAnotacao.ValidateIdAnotacaoPut(id);
        }

        public bool ValidateNamePost(Anotacao anotacao)
        {
            return repositoryAnotacao.ValidateNamePost(anotacao);
        }

        public bool ValidateNamePut(Anotacao anotacao)
        {
            return repositoryAnotacao.ValidateNamePut(anotacao);
        }
    }
}