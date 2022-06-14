using DevLabs.Domain.Core.Interfaces.Repositories;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Enums;
using DevLabs.Domain.Pagination;
using DevLabs.Infrastructure.Data.Repositorys.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevLabs.Infrastructure.Data.Repositorys
{
    public class RepositoryMenu : RepositoryBase<Menu>, IRepositoryMenu
    {
        private readonly AppDbContext appDbContext;

        public RepositoryMenu(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PagedList<Menu>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            return await Task.FromResult(PagedList<Menu>
            .ToPagedList(appDbContext.Set<Menu>()
            .Where(x => parametersPalavraChave.Status == 0 || x.Status == (int)parametersPalavraChave.Status)
            .Where(x => EF.Functions.Like(x.Titulo, $"%{parametersPalavraChave.PalavraChave}%"))
            .Where(x => (parametersPalavraChave.Id == null) || parametersPalavraChave.Id.Contains(x.Id))
            .AsNoTracking(),
             parametersPalavraChave.NumeroPagina, parametersPalavraChave.ResultadosExibidos));
        }

        public bool ValidateIdMenuPut(Guid id)
        {
            return appDbContext.Menus.Any(p => p.Id == id);
        }

        public bool ValidateNamePost(Menu menu)
        {
            return appDbContext.Menus
                               .AsNoTracking()
                               .Any(x => x.Titulo.ToLower() == menu.Titulo.ToLower()
                                    && x.Status != (int)Status.Excluido);
        }

        public bool ValidateNamePut(Menu menu)
        {
            return appDbContext.Anotacoes
                               .AsNoTracking()
                               .Any(x => x.Titulo.ToLower() == menu.Titulo.ToLower()
                                     && x.Id != menu.Id
                                        && x.Status != (int)Status.Excluido);
        }
    }
}