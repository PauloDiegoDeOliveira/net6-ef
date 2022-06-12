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
    public class RepositoryProjeto : RepositoryBase<Projeto>, IRepositoryProjeto
    {
        private readonly AppDbContext appDbContext;

        public RepositoryProjeto(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PagedList<Projeto>> GetPaginationAsync(ParametersPalavraChave parameters)
        {
            return await Task.FromResult(PagedList<Projeto>
            .ToPagedList(appDbContext.Set<Projeto>()
            .Where(x => parameters.Status == 0 ? true : x.Status == (int)parameters.Status)
            .Where(x => EF.Functions.Like(x.Titulo, $"%{parameters.PalavraChave}%"))
            .Where(x => (parameters.Id == null) || parameters.Id.Contains(x.Id))
            .AsNoTracking(),
             parameters.NumeroPagina, parameters.ResultadosExibidos));
        }

        public override async Task<Projeto> PutAsync(Projeto projeto)
        {
            return await base.PutAsync(await UpdateAsync(projeto));
        }

        private async Task<Projeto> UpdateAsync(Projeto projeto)
        {
            Projeto consulta = await appDbContext.Projetos
                                    .Include(x => x.URLSHomologacao)
                                    .Include(x => x.URLSProducao)
                                    .Include(x => x.URLSDocumentacao)
                                    .Include(x => x.Contas)
                                    .FirstOrDefaultAsync(x => x.Id == projeto.Id);
            if (consulta == null)
                return null;

            appDbContext.Entry(consulta).CurrentValues.SetValues(projeto);

            await UpdateURLHomologacao(projeto, consulta);
            await UpdateURLProducao(projeto, consulta);
            await UpdateURLDocumentacao(projeto, consulta);
            await UpdateConta(projeto, consulta);

            return consulta;
        }

        private static async Task UpdateURLHomologacao(Projeto projeto, Projeto consulta)
        {
            consulta.URLSHomologacao.Clear();

            foreach (URLHomologacao urlHomologacao in projeto.URLSHomologacao)
            {
                consulta.URLSHomologacao.Add(urlHomologacao);
            }

            await Task.CompletedTask;
        }

        private static async Task UpdateURLProducao(Projeto projeto, Projeto consulta)
        {
            consulta.URLSProducao.Clear();

            foreach (URLProducao urlProducao in projeto.URLSProducao)
            {
                consulta.URLSProducao.Add(urlProducao);
            }

            await Task.CompletedTask;
        }

        private static async Task UpdateURLDocumentacao(Projeto projeto, Projeto consulta)
        {
            consulta.URLSDocumentacao.Clear();

            foreach (URLDocumentacao urlDocumentacao in projeto.URLSDocumentacao)
            {
                consulta.URLSDocumentacao.Add(urlDocumentacao);
            }

            await Task.CompletedTask;
        }

        private static async Task UpdateConta(Projeto projeto, Projeto consulta)
        {
            consulta.Contas.Clear();

            foreach (Conta conta in projeto.Contas)
            {
                consulta.Contas.Add(conta);
            }

            await Task.CompletedTask;
        }

        public async Task<Projeto> GetByIdDetailsAsync(Guid id)
        {
            Projeto project = await appDbContext.Projetos
                .Include(x => x.URLSHomologacao)
                .Include(x => x.URLSProducao)
                .Include(x => x.URLSDocumentacao)
                .Include(x => x.Contas)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return project;
        }

        public bool ValidateIdProjectPut(Guid id)
        {
            return appDbContext.Projetos.Any(p => p.Id == id);
        }

        public bool ValidateNamePost(Projeto projeto)
        {
            return appDbContext.Projetos
                               .AsNoTracking()
                               .Any(x => x.Titulo.ToLower() == projeto.Titulo.ToLower()
                                    && x.Status != (int)Status.Excluido);
        }

        public bool ValidateNamePut(Projeto projeto)
        {
            return appDbContext.Projetos
                               .AsNoTracking()
                               .Any(x => x.Titulo.ToLower() == projeto.Titulo.ToLower()
                                    && x.Id != projeto.Id
                                        && x.Status != (int)Status.Excluido);
        }

        public bool ValidateIdURLHomologacaoPut(Guid id)
        {
            return appDbContext.URLSHomolocacao.Any(p => p.Id == id);
        }

        public bool ValidateIdURLProducaoPut(Guid id)
        {
            return appDbContext.URLSProducao.Any(p => p.Id == id);
        }

        public bool ValidateIdURLDocumentacaoPut(Guid id)
        {
            return appDbContext.URLSDocumentacao.Any(p => p.Id == id);
        }

        public bool ValidateIdContaPut(Guid id)
        {
            return appDbContext.Contas.Any(p => p.Id == id);
        }
    }
}