using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasterApiTatis.Migrations
{
    /// <inheritdoc />
    public partial class migracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "depar",
                columns: table => new
                {
                    coddep = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desdep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_depar", x => x.coddep);
                });

            migrationBuilder.CreateTable(
                name: "grup",
                columns: table => new
                {
                    codgrup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desgrup = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grup", x => x.codgrup);
                });

            migrationBuilder.CreateTable(
                name: "subgrup",
                columns: table => new
                {
                    codsubgrup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dessubgrup = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subgrup", x => x.codsubgrup);
                });

            migrationBuilder.CreateTable(
                name: "tippro",
                columns: table => new
                {
                    codtippro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    destippro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valexi = table.Column<bool>(type: "bit", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tippro", x => x.codtippro);
                });

            migrationBuilder.CreateTable(
                name: "uni",
                columns: table => new
                {
                    coduni = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desuni = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uni", x => x.coduni);
                });

            migrationBuilder.CreateTable(
                name: "prod",
                columns: table => new
                {
                    codpro = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    despro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    exipro = table.Column<int>(type: "int", nullable: false),
                    tippro = table.Column<int>(type: "int", nullable: true),
                    tipoProductcodtippro = table.Column<int>(type: "int", nullable: false),
                    coddep = table.Column<int>(type: "int", nullable: true),
                    departamentocoddep = table.Column<int>(type: "int", nullable: false),
                    codgrup = table.Column<int>(type: "int", nullable: true),
                    grupocodgrup = table.Column<int>(type: "int", nullable: false),
                    codsubgrup = table.Column<int>(type: "int", nullable: false),
                    subgrupocodsubgrup = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prod", x => x.codpro);
                    table.ForeignKey(
                        name: "FK_prod_depar_departamentocoddep",
                        column: x => x.departamentocoddep,
                        principalTable: "depar",
                        principalColumn: "coddep",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prod_grup_grupocodgrup",
                        column: x => x.grupocodgrup,
                        principalTable: "grup",
                        principalColumn: "codgrup",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prod_subgrup_subgrupocodsubgrup",
                        column: x => x.subgrupocodsubgrup,
                        principalTable: "subgrup",
                        principalColumn: "codsubgrup",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prod_tippro_tipoProductcodtippro",
                        column: x => x.tipoProductcodtippro,
                        principalTable: "tippro",
                        principalColumn: "codtippro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uni_pro",
                columns: table => new
                {
                    codunipro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codpro = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    coduni = table.Column<int>(type: "int", nullable: false),
                    precio1 = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    precio2 = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    precio3 = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    costo1 = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    costo2 = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    costo3 = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uni_pro", x => x.codunipro);
                    table.ForeignKey(
                        name: "FK_uni_pro_prod_codpro",
                        column: x => x.codpro,
                        principalTable: "prod",
                        principalColumn: "codpro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prod_departamentocoddep",
                table: "prod",
                column: "departamentocoddep");

            migrationBuilder.CreateIndex(
                name: "IX_prod_grupocodgrup",
                table: "prod",
                column: "grupocodgrup");

            migrationBuilder.CreateIndex(
                name: "IX_prod_subgrupocodsubgrup",
                table: "prod",
                column: "subgrupocodsubgrup");

            migrationBuilder.CreateIndex(
                name: "IX_prod_tipoProductcodtippro",
                table: "prod",
                column: "tipoProductcodtippro");

            migrationBuilder.CreateIndex(
                name: "IX_uni_pro_codpro",
                table: "uni_pro",
                column: "codpro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "uni");

            migrationBuilder.DropTable(
                name: "uni_pro");

            migrationBuilder.DropTable(
                name: "prod");

            migrationBuilder.DropTable(
                name: "depar");

            migrationBuilder.DropTable(
                name: "grup");

            migrationBuilder.DropTable(
                name: "subgrup");

            migrationBuilder.DropTable(
                name: "tippro");
        }
    }
}
