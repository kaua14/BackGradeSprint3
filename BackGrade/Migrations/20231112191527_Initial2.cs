using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackGrade.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_CLIENTE");

            migrationBuilder.DropTable(
                name: "T_FEEDBACK");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RespostaChatGPT = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReclameAquiReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Comentario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Avaliacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProdutoModelId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclameAquiReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReclameAquiReviews_Produtos_ProdutoModelId",
                        column: x => x.ProdutoModelId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReclameAquiReviews_ProdutoModelId",
                table: "ReclameAquiReviews",
                column: "ProdutoModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReclameAquiReviews");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.CreateTable(
                name: "T_CLIENTE",
                columns: table => new
                {
                    ID_CLIENTE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CNPJ_CLIENTE_JURIDICO = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CPF_CLIENTE_FISICO = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    EMAIL_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NM_CLIENTE_FISICO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RZ_SOCIAL_CLIENTE_JURIDICO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SENHA_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TELEFONE_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TP_CLIENTE = table.Column<string>(type: "NVARCHAR2(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CLIENTE", x => x.ID_CLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "T_FEEDBACK",
                columns: table => new
                {
                    ID_FEEDBACK = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ANALISE_FEEDBACK = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESC_FEEDBACK = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DT_FEEDBACK = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ID_CLIENTE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NOTA_FEEDBACK = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_FEEDBACK", x => x.ID_FEEDBACK);
                });
        }
    }
}
