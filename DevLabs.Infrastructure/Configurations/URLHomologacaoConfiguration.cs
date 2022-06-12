using DevLabs.Domain.Entitys;
using DevLabs.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLabs.Infrastructure.Configurations
{
    public class URLHomologacaoConfiguration : ConfigurationBase<URLHomologacao>
    {
        public override void Configure(EntityTypeBuilder<URLHomologacao> builder)
        {
            tableName = "URLSHomologacao";

            base.Configure(builder);

            builder.Property(p => p.URL)
                   .HasColumnName("URL")
                   .HasColumnType("varchar(200)");
        }
    }
}