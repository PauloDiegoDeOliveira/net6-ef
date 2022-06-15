using DevLabs.Domain.Entitys;
using DevLabs.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLabs.Infrastructure.Configurations
{
    public class UrlHomologacaoConfiguration : ConfigurationBase<UrlHomologacao>
    {
        public override void Configure(EntityTypeBuilder<UrlHomologacao> builder)
        {
            tableName = "URLSHomologacao";

            base.Configure(builder);

            builder.Property(p => p.URL)
                   .HasColumnName("URL")
                   .HasMaxLength(200)
                   .HasColumnType("varchar(200)");
        }
    }
}