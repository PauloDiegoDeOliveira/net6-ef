using DevLabs.Domain.Entitys;
using DevLabs.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLabs.Infrastructure.Configurations
{
    public class ContaConfiguration : ConfigurationBase<Conta>
    {
        public override void Configure(EntityTypeBuilder<Conta> builder)
        {
            tableName = "Contas";

            base.Configure(builder);

            builder.Property(p => p.Usuario)
                   .IsRequired()
                   .HasColumnName("Usuario")
                   .HasColumnType("varchar(150)");

            builder.Property(p => p.Senha)
                   .HasColumnName("Senha")
                   .HasColumnType("varchar(150)");
        }
    }
}