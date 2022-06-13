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
                   .HasMaxLength(150)
                   .HasColumnType("varchar(150)");

            builder.Property(p => p.Descricao)
                   .HasColumnName("Descricao")
                   .HasMaxLength(300)
                   .HasColumnType("varchar(300)");

            builder.Property(p => p.Rota)
                   .HasColumnName("Rota")
                   .HasMaxLength(300)
                   .HasColumnType("varchar(300)");
        }
    }
}