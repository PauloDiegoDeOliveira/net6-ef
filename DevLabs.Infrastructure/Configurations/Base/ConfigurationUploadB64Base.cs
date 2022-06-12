using DevLabs.Domain.Entitys.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLabs.Infrastructure.Configurations.Base
{
    public class ConfigurationUploadB64Base<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : UploadB64Base
    {
        protected string tableName;

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(tableName);

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Status)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("Status")
                   .HasColumnType("int")
                   .HasDefaultValue(1);

            builder.Property(x => x.NomeArquivo)
                   .HasColumnName("NomeArquivo")
                   .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.CaminhoRelativo)
                  .HasMaxLength(300)
                  .HasColumnName("CaminhoRelativo")
                  .HasColumnType("varchar(300)");

            builder.Property(p => p.CaminhoAbsoluto)
                  .HasMaxLength(300)
                  .HasColumnName("CaminhoAbsoluto")
                  .HasColumnType("varchar(300)");

            builder.Property(p => p.CaminhoFisico)
                   .HasMaxLength(300)
                   .HasColumnName("CaminhoFisico")
                   .HasColumnType("varchar(300)");
        }
    }
}