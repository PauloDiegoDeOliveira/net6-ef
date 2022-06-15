using DevLabs.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevLabs.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<UrlHomologacao> URLSHomolocacao { get; set; }
        public DbSet<UrlProducao> URLSProducao { get; set; }
        public DbSet<UrlDocumentacao> URLSDocumentacao { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Anotacao> Anotacoes { get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("AlteradoEm").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}