using DevLabs.Domain.Core.Interfaces.Service.Base;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using System;
using System.Threading.Tasks;

namespace DevLabs.Domain.Core.Interfaces.Service
{
    public interface IServiceMenu : IServiceBase<Menu>
    {
        Task<PagedList<Menu>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        bool ValidateIdMenuPut(Guid id);

        bool ValidateNamePost(Menu menu);

        bool ValidateNamePut(Menu menu);
    }
}