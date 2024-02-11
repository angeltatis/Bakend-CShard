using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasterApiTatis.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    coddep = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desdep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.coddep);
                });

            migrationBuilder.CreateTable(
                name: "grupo",
                columns: table => new
                {
                    codgrup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desgrup = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo", x => x.codgrup);
                });

            migrationBuilder.CreateTable(
                name: "subgrupo_producto",
                columns: table => new
                {
                    codsubgrup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dessubgrup = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subgrupo_producto", x => x.codsubgrup);
                });

            migrationBuilder.CreateTable(
                name: "tipo_producto",
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
                    table.PrimaryKey("PK_tipo_producto", x => x.codtippro);
                });

            migrationBuilder.CreateTable(
                name: "unidad",
                columns: table => new
                {
                    coduni = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desuni = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidad", x => x.coduni);
                });

            migrationBuilder.CreateTable(
                name: "producto",
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
                    imgurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.codpro);
                    table.ForeignKey(
                        name: "FK_producto_departamento_departamentocoddep",
                        column: x => x.departamentocoddep,
                        principalTable: "departamento",
                        principalColumn: "coddep",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_producto_grupo_grupocodgrup",
                        column: x => x.grupocodgrup,
                        principalTable: "grupo",
                        principalColumn: "codgrup",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_producto_subgrupo_producto_subgrupocodsubgrup",
                        column: x => x.subgrupocodsubgrup,
                        principalTable: "subgrupo_producto",
                        principalColumn: "codsubgrup",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_producto_tipo_producto_tipoProductcodtippro",
                        column: x => x.tipoProductcodtippro,
                        principalTable: "tipo_producto",
                        principalColumn: "codtippro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "unidad_producto",
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
                    table.PrimaryKey("PK_unidad_producto", x => x.codunipro);
                    table.ForeignKey(
                        name: "FK_unidad_producto_producto_codpro",
                        column: x => x.codpro,
                        principalTable: "producto",
                        principalColumn: "codpro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_producto_departamentocoddep",
                table: "producto",
                column: "departamentocoddep");

            migrationBuilder.CreateIndex(
                name: "IX_producto_grupocodgrup",
                table: "producto",
                column: "grupocodgrup");

            migrationBuilder.CreateIndex(
                name: "IX_producto_subgrupocodsubgrup",
                table: "producto",
                column: "subgrupocodsubgrup");

            migrationBuilder.CreateIndex(
                name: "IX_producto_tipoProductcodtippro",
                table: "producto",
                column: "tipoProductcodtippro");

            migrationBuilder.CreateIndex(
                name: "IX_unidad_producto_codpro",
                table: "unidad_producto",
                column: "codpro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "unidad");

            migrationBuilder.DropTable(
                name: "unidad_producto");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "grupo");

            migrationBuilder.DropTable(
                name: "subgrupo_producto");

            migrationBuilder.DropTable(
                name: "tipo_producto");
        }
    }
}
