using DevLabs.Domain.Core.Interfaces.Repositories;
using DevLabs.Domain.Core.Interfaces.Service;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using DevLabs.Domain.Services.Base;
using System;
using System.Threading.Tasks;

namespace DevLabs.Domain.Services
{
    public class ServiceMenu : ServiceBase<Menu>, IServiceMenu
    {
        private readonly IRepositoryMenu repositoryMenu;

        public ServiceMenu(IRepositoryMenu repositoryMenu) : base(repositoryMenu)
        {
            this.repositoryMenu = repositoryMenu;
        }

        public async Task<PagedList<Menu>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            return await repositoryMenu.GetPaginationAsync(parametersPalavraChave);
        }

        public bool ValidateIdMenuPut(Guid id)
        {
            return repositoryMenu.ValidateIdMenuPut(id);
        }

        public bool ValidateNamePost(Menu menu)
        {
            return repositoryMenu.ValidateNamePost(menu);
        }

        public bool ValidateNamePut(Menu menu)
        {
            return repositoryMenu.ValidateNamePut(menu);
        }
    }
}