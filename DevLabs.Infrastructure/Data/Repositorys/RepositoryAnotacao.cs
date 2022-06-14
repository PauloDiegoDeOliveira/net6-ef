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
    public class RepositoryAnotacao : RepositoryBase<Anotacao>, IRepositoryAnotacao
    {
        private readonly AppDbContext appDbContext;

        public RepositoryAnotacao(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PagedList<Anotacao>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            return await Task.FromResult(PagedList<Anotacao>
            .ToPagedList(appDbContext.Set<Anotacao>()
            .Where(x => parametersPalavraChave.Status == 0 || x.Status == (int)parametersPalavraChave.Status)
            .Where(x => EF.Functions.Like(x.Titulo, $"%{parametersPalavraChave.PalavraChave}%"))
            .Where(x => (parametersPalavraChave.Id == null) || parametersPalavraChave.Id.Contains(x.Id))
            .AsNoTracking(),
             parametersPalavraChave.NumeroPagina, parametersPalavraChave.ResultadosExibidos));
        }

        public bool ValidateIdAnotacaoPut(Guid id)
        {
            return appDbContext.Anotacoes.Any(p => p.Id == id);
        }

        public bool ValidateNamePost(Anotacao anotacao)
        {
            return appDbContext.Anotacoes
                               .AsNoTracking()
                               .Any(x => x.Titulo.ToLower() == anotacao.Titulo.ToLower()
                                    && x.Status != (int)Status.Excluido);
        }

        public bool ValidateNamePut(Anotacao anotacao)
        {
            return appDbContext.Anotacoes
                               .AsNoTracking()
                               .Any(x => x.Titulo.ToLower() == anotacao.Titulo.ToLower()
                                    && x.Id != anotacao.Id
                                        && x.Status != (int)Status.Excluido);
        }
    }
}