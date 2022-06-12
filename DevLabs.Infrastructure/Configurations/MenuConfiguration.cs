using DevLabs.Domain.Entitys;
using DevLabs.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLabs.Infrastructure.Configurations
{
    public class MenuConfiguration : ConfigurationUploadFormBase<Menu>
    {
        public override void Configure(EntityTypeBuilder<Menu> builder)
        {
            tableName = "Menus";

            base.Configure(builder);

            builder.Property(p => p.Titulo)
                   .IsRequired()
                   .HasColumnName("Titulo")
                   .HasColumnType("varchar(150)");

            builder.Property(p => p.Descricao)
                   .HasColumnName("Descricao")
                   .HasColumnType("varchar(150)");

            builder.Property(p => p.Rota)
                   .HasColumnName("Rota")
                   .HasColumnType("varchar(150)");
        }
    }
}