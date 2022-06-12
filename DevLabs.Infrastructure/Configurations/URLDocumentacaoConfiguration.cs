using DevLabs.Domain.Entitys;
using DevLabs.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLabs.Infrastructure.Configurations
{
    public class URLDocumentacaoConfiguration : ConfigurationBase<URLDocumentacao>
    {
        public override void Configure(EntityTypeBuilder<URLDocumentacao> builder)
        {
            tableName = "URLSDocumentacao";

            base.Configure(builder);

            builder.Property(p => p.URL)
                   .HasColumnName("URL")
                   .HasColumnType("varchar(200)");
        }
    }
}