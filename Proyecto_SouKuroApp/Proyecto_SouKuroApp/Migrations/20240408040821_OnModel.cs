using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_SouKuroApp.Migrations
{
    /// <inheritdoc />
    public partial class OnModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "producto_Detalles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "producto_Detalles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductoId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "producto_Detalles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductoId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "producto_Detalles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductoId",
                value: 14);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "producto_Detalles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductoId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "producto_Detalles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductoId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "producto_Detalles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductoId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "producto_Detalles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductoId",
                value: 0);
        }
    }
}
