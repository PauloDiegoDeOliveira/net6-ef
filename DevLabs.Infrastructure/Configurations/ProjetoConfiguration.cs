using DevLabs.Domain.Entitys;
using DevLabs.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLabs.Infrastructure.Configurations
{
    public class ProjetoConfiguration<TEntity> : ConfigurationUploadB64Base<Projeto>
    {
        public override void Configure(EntityTypeBuilder<Projeto> builder)
        {
            tableName = "Projetos";

            base.Configure(builder);

            builder.Property(p => p.Titulo)
                   .IsRequired()
                   .HasColumnName("Titulo")
                   .HasColumnType("varchar(150)");

            builder.Property(p => p.Descricao)
                   .HasColumnName("Descricao")
                   .HasColumnType("varchar(150)");

            builder.Property(p => p.Observacao)
                   .HasColumnName("Observacao")
                   .HasColumnType("varchar(500)");

            builder.Property(p => p.Situacao)
                   .HasColumnName("Situacao")
                   .HasColumnType("int");

            builder.Property(p => p.Ordem)
                   .HasColumnName("Ordem")
                   .HasColumnType("int");

            builder.Property(p => p.Progresso)
                   .HasColumnName("Progresso")
                   .HasColumnType("int");

            builder.Property(p => p.SubTitulo)
                   .HasColumnName("SubTitulo")
                   .HasColumnType("varchar(150)");

            builder.Property(p => p.Prioridade)
                   .HasColumnName("Prioridade")
                   .HasColumnType("int");
        }
    }
}