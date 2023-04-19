using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OficinaMeurer.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Adicionado_Tabelas_Para_OrdemDeServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "CLIENTE",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESPONSAVEL",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESPONSAVEL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SERVICO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    ValorMaoDeObra = table.Column<decimal>(type: "numeric", nullable: true),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ORDEM_DE_SERVICO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCliente = table.Column<long>(type: "bigint", nullable: false),
                    IdResponsavel = table.Column<long>(type: "bigint", nullable: true),
                    Solicitacao = table.Column<string>(type: "text", nullable: false),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataFim = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDEM_DE_SERVICO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDEM_DE_SERVICO_CLIENTE_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "CLIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDEM_DE_SERVICO_RESPONSAVEL_IdResponsavel",
                        column: x => x.IdResponsavel,
                        principalTable: "RESPONSAVEL",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO_SERVICO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdProduto = table.Column<long>(type: "bigint", nullable: false),
                    IdServico = table.Column<long>(type: "bigint", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO_SERVICO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUTO_SERVICO_PRODUTO_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUTO_SERVICO_SERVICO_IdServico",
                        column: x => x.IdServico,
                        principalTable: "SERVICO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO_ORDEM_DE_SERVICO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdProduto = table.Column<long>(type: "bigint", nullable: false),
                    IdOrdemDeServico = table.Column<long>(type: "bigint", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO_ORDEM_DE_SERVICO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUTO_ORDEM_DE_SERVICO_ORDEM_DE_SERVICO_IdOrdemDeServico",
                        column: x => x.IdOrdemDeServico,
                        principalTable: "ORDEM_DE_SERVICO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUTO_ORDEM_DE_SERVICO_PRODUTO_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SERVICO_ORDEM_DE_SERVICO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdServico = table.Column<long>(type: "bigint", nullable: false),
                    IdOrdemDeServico = table.Column<long>(type: "bigint", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICO_ORDEM_DE_SERVICO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SERVICO_ORDEM_DE_SERVICO_ORDEM_DE_SERVICO_IdOrdemDeServico",
                        column: x => x.IdOrdemDeServico,
                        principalTable: "ORDEM_DE_SERVICO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SERVICO_ORDEM_DE_SERVICO_SERVICO_IdServico",
                        column: x => x.IdServico,
                        principalTable: "SERVICO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDEM_DE_SERVICO_IdCliente",
                table: "ORDEM_DE_SERVICO",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ORDEM_DE_SERVICO_IdResponsavel",
                table: "ORDEM_DE_SERVICO",
                column: "IdResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_ORDEM_DE_SERVICO_IdOrdemDeServico",
                table: "PRODUTO_ORDEM_DE_SERVICO",
                column: "IdOrdemDeServico");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_ORDEM_DE_SERVICO_IdProduto",
                table: "PRODUTO_ORDEM_DE_SERVICO",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_SERVICO_IdProduto",
                table: "PRODUTO_SERVICO",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_SERVICO_IdServico",
                table: "PRODUTO_SERVICO",
                column: "IdServico");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICO_ORDEM_DE_SERVICO_IdOrdemDeServico",
                table: "SERVICO_ORDEM_DE_SERVICO",
                column: "IdOrdemDeServico");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICO_ORDEM_DE_SERVICO_IdServico",
                table: "SERVICO_ORDEM_DE_SERVICO",
                column: "IdServico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTO_ORDEM_DE_SERVICO");

            migrationBuilder.DropTable(
                name: "PRODUTO_SERVICO");

            migrationBuilder.DropTable(
                name: "SERVICO_ORDEM_DE_SERVICO");

            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "ORDEM_DE_SERVICO");

            migrationBuilder.DropTable(
                name: "SERVICO");

            migrationBuilder.DropTable(
                name: "RESPONSAVEL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "CLIENTE",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
