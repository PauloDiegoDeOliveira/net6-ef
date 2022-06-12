using DevLabs.Domain.Core.Interfaces.Service.Base;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using System;
using System.Threading.Tasks;

namespace DevLabs.Domain.Core.Interfaces.Service
{
    public interface IServiceAnotacao : IServiceBase<Anotacao>
    {
        Task<PagedList<Anotacao>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        bool ValidateIdAnotacaoPut(Guid id);

        bool ValidateNamePost(Anotacao anotacao);

        bool ValidateNamePut(Anotacao anotacao);
    }
}