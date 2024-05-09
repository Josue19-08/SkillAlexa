using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skill.DA.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "ListaDeseos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoProducto = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cantidadProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaDeseos", x => x.id);
                    table.ForeignKey(
                        name: "FK_ListaDeseos_Producto_codigoProducto",
                        column: x => x.codigoProducto,
                        principalTable: "Producto",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListaDeseos_codigoProducto",
                table: "ListaDeseos",
                column: "codigoProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaDeseos");

            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
