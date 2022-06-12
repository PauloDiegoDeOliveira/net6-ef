using DevLabs.Domain.Core.Interfaces.Repositories.Base;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using System;
using System.Threading.Tasks;

namespace DevLabs.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryMenu : IRepositoryBase<Menu>
    {
        Task<PagedList<Menu>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        bool ValidateIdMenuPut(Guid id);

        bool ValidateNamePost(Menu menu);

        bool ValidateNamePut(Menu menu);
    }
}