using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_SouKuroApp.Migrations
{
    /// <inheritdoc />
    public partial class ModificandoTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "productos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
