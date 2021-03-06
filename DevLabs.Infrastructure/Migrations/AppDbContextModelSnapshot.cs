// <auto-generated />
using System;
using DevLabs.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevLabs.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DevLabs.Domain.Entitys.Anotacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("CaminhoAbsoluto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CaminhoFisico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CaminhoRelativo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Descricao");

                    b.Property<string>("ExtensaoArquivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HoraEnvio")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("NomeArquivoBanco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeArquivoOriginal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rota")
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Rota");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<long>("TamanhoEmBytes")
                        .HasColumnType("bigint");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Anotacoes", (string)null);
                });

            modelBuilder.Entity("DevLabs.Domain.Entitys.Conta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjetoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Senha");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Usuario");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Contas", (string)null);
                });

            modelBuilder.Entity("DevLabs.Domain.Entitys.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("CaminhoAbsoluto")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("CaminhoAbsoluto");

                    b.Property<string>("CaminhoFisico")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("CaminhoFisico");

                    b.Property<string>("CaminhoRelativo")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("CaminhoRelativo");

                    b.Property<string>("ContentType")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ContentType");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Descricao");

                    b.Property<string>("ExtensaoArquivo")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ExtensaoArquivo");

                    b.Property<DateTime>("HoraEnvio")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("NomeArquivoBanco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("NomeArquivoBanco")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("NomeArquivoOriginal")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("NomeArquivoOriginal");

                    b.Property<string>("Rota")
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Rota");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<string>("TamanhoEmBytes")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("TamanhoEmBytes");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("DevLabs.Domain.Entitys.Projeto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("CaminhoAbsoluto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CaminhoFisico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CaminhoRelativo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoProjeto")
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraEnvio")
                        .HasColumnType("datetime2");

                    b.Property<int>("Instituto")
                        .HasColumnType("int");

                    b.Property<Guid>("NomeArquivo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ordem")
                        .HasColumnType("int");

                    b.Property<int>("Prioridade")
                        .HasColumnType("int");

                    b.Property<int>("Progresso")
                        .HasColumnType("int");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("SubTitulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("DevLabs.Domain.Entitys.URLDocumentacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjetoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("URL");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("URLSDocumentacao", (string)null);
                });

            modelBuilder.Entity("DevLabs.Domain.Entitys.URLHomologacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjetoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("URL");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("URLSHomologacao", (string)null);
                });

            modelBuilder.Entity("DevLabs.Domain.Entitys.URLProducao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjetoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("URL");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("URLSProducao", (string)null);
                });

            modelBuilder.Entity("DevLabs.Domain.Entitys.Conta", b =>
                {
                    b.HasOne("DevLabs.Domain.Entitys.Projeto", "Projeto")
                        .WithMany("Contas")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("DevLabs.Domain.Entitys.URLDocumentacao", b =>
                {
                    b.HasOne("DevLabs.Domain.Entitys.Projeto", "Projeto")
                        .WithMany("URLSDocumentacao")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("DevLabs.Domain.Entitys.URLHomologacao", b =>
                {
                    b.HasOne("DevLabs.Domain.Entitys.Projeto", "Projeto")
                        .WithMany("URLSHomologacao")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("DevLabs.Domain.Entitys.URLProducao", b =>
                {
                    b.HasOne("DevLabs.Domain.Entitys.Projeto", "Projeto")
                        .WithMany("URLSProducao")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("DevLabs.Domain.Entitys.Projeto", b =>
                {
                    b.Navigation("Contas");

                    b.Navigation("URLSDocumentacao");

                    b.Navigation("URLSHomologacao");

                    b.Navigation("URLSProducao");
                });
#pragma warning restore 612, 618
        }
    }
}
