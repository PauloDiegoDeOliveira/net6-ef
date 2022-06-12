using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace DevLabs.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anotacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(150)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: true),
                    Rota = table.Column<string>(type: "varchar(150)", nullable: true),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false, defaultValue: 1),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeArquivoBanco = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TamanhoEmBytes = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtensaoArquivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeArquivoOriginal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaminhoRelativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaminhoAbsoluto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaminhoFisico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anotacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(150)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: true),
                    Rota = table.Column<string>(type: "varchar(150)", nullable: true),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false, defaultValue: 1),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeArquivoBanco = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TamanhoEmBytes = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ContentType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ExtensaoArquivo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    NomeArquivoOriginal = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    CaminhoRelativo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    CaminhoAbsoluto = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    CaminhoFisico = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    HoraEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progresso = table.Column<int>(type: "int", nullable: false),
                    SubTitulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    EstadoProjeto = table.Column<int>(type: "int", nullable: false),
                    Instituto = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeArquivo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaminhoRelativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaminhoAbsoluto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaminhoFisico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Usuario = table.Column<string>(type: "varchar(150)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(150)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false, defaultValue: 1),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "URLSDocumentacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URL = table.Column<string>(type: "varchar(200)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false, defaultValue: 1),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLSDocumentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_URLSDocumentacao_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "URLSHomologacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URL = table.Column<string>(type: "varchar(200)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false, defaultValue: 1),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLSHomologacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_URLSHomologacao_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "URLSProducao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URL = table.Column<string>(type: "varchar(200)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false, defaultValue: 1),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLSProducao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_URLSProducao_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_ProjetoId",
                table: "Contas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_URLSDocumentacao_ProjetoId",
                table: "URLSDocumentacao",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_URLSHomologacao_ProjetoId",
                table: "URLSHomologacao",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_URLSProducao_ProjetoId",
                table: "URLSProducao",
                column: "ProjetoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anotacoes");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "URLSDocumentacao");

            migrationBuilder.DropTable(
                name: "URLSHomologacao");

            migrationBuilder.DropTable(
                name: "URLSProducao");

            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}