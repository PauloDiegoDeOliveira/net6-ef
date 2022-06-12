using DevLabs.Domain.Core.Interfaces.Repositories.Base;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using System;
using System.Threading.Tasks;

namespace DevLabs.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryProjeto : IRepositoryBase<Projeto>
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