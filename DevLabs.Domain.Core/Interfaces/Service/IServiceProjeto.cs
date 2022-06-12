using DevLabs.Domain.Core.Interfaces.Service.Base;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using System;
using System.Threading.Tasks;

namespace DevLabs.Domain.Core.Interfaces.Service
{
    public interface IServiceProjeto : IServiceBase<Projeto>
    {
        Task<PagedList<Projeto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        Task<Projeto> GetByIdDetailsAsync(Guid id);

        bool ValidateIdProjectPut(Guid id);

        bool ValidateNamePost(Projeto projeto);

        bool ValidateNamePut(Projeto projeto);

        bool ValidateIdURLHomologacaoPut(Guid id);

        bool ValidateIdURLProducaoPut(Guid id);

        bool ValidateIdURLDocumentacaoPut(Guid id);

        bool ValidateIdContaPut(Guid id);
    }
}