using DevLabs.Domain.Entitys;
using DevLabs.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLabs.Infrastructure.Configurations
{
    public class ProjetoConfiguration : ConfigurationUploadB64Base<Projeto>
    {
        public override void Configure(EntityTypeBuilder<Projeto> builder)
        {
            tableName = "Projetos";

            base.Configure(builder);

            builder.Property(p => p.Titulo)
                   .IsRequired()
                   .HasColumnName("Titulo")
                   .HasMaxLength(150)
                   .HasColumnType("varchar(150)");

            builder.Property(p => p.Descricao)
                   .HasColumnName("Descricao")
                   .HasMaxLength(300)
                   .HasColumnType("varchar(300)");

            builder.Property(p => p.Observacao)
                   .HasColumnName("Observacao")
                   .HasMaxLength(500)
                   .HasColumnType("varchar(500)");

            builder.Property(p => p.Situacao)
                   .HasColumnName("Situacao")
                   .HasMaxLength(100)
                   .HasColumnType("int");

            builder.Property(p => p.Ordem)
                   .HasColumnName("Ordem")
                   .HasMaxLength(100)
                   .HasColumnType("int");

            builder.Property(p => p.Progresso)
                   .HasColumnName("Progresso")
                   .HasMaxLength(100)
                   .HasColumnType("int");

            builder.Property(p => p.SubTitulo)
                   .HasColumnName("SubTitulo")
                   .HasMaxLength(150)
                   .HasColumnType("varchar(150)");

            builder.Property(p => p.Prioridade)
                   .HasColumnName("Prioridade")
                   .HasMaxLength(100)
                   .HasColumnType("int");
        }
    }
}