using DevLabs.Domain.Core.Interfaces.Repositories;
using DevLabs.Domain.Entitys;
using DevLabs.FakeData.AnotacaoData;
using DevLabs.Infrastructure.Data;
using DevLabs.Infrastructure.Data.Repositorys;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DevLabs.Repository.Tests.Repository
{
    public class AnotacaoRepositoryTest : IDisposable
    {
        private readonly IRepositoryAnotacao repositoryAnotacao;
        private readonly AppDbContext appDbContext;
        private readonly Anotacao anotacao;
        private readonly AnotacaoFaker anotacaoFaker;

        public AnotacaoRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseInMemoryDatabase("Db_Fake");

            appDbContext = new AppDbContext(optionsBuilder.Options);
            repositoryAnotacao = new RepositoryAnotacao(appDbContext);

            anotacaoFaker = new AnotacaoFaker();
            anotacao = anotacaoFaker.Generate();
        }

        private async Task<List<Anotacao>> InsereRegistros()
        {
            List<Anotacao> anotacoes = anotacaoFaker.Generate(100);

            foreach (Anotacao item in anotacoes)
            {
                item.GuidValue(Guid.Empty);

                await appDbContext.Anotacoes.AddAsync(item);
            }

            await appDbContext.SaveChangesAsync();

            return anotacoes;
        }

        [Fact]
        public async Task GetAnotacoesAsync_ComRetorno()
        {
            List<Anotacao> registros = await InsereRegistros();
            IEnumerable<Anotacao> retorno = await repositoryAnotacao.GetAllAsync();

            retorno.Should().HaveCount(registros.Count);
        }

        public void Dispose()
        {
            appDbContext.Database.EnsureDeleted();
        }
    }
}