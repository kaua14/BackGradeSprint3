using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackGrade.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_CLIENTE",
                columns: table => new
                {
                    ID_CLIENTE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TP_CLIENTE = table.Column<string>(type: "NVARCHAR2(1)", nullable: false),
                    EMAIL_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TELEFONE_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SENHA_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NM_CLIENTE_FISICO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CPF_CLIENTE_FISICO = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    RZ_SOCIAL_CLIENTE_JURIDICO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CNPJ_CLIENTE_JURIDICO = table.Column<long>(type: "NUMBER(19)", nullable: true)
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
                    ID_CLIENTE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DT_FEEDBACK = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DESC_FEEDBACK = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ANALISE_FEEDBACK = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NOTA_FEEDBACK = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_FEEDBACK", x => x.ID_FEEDBACK);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_CLIENTE");

            migrationBuilder.DropTable(
                name: "T_FEEDBACK");
        }
    }
}
