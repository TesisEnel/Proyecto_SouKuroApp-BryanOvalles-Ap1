using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_SouKuroApp.Migrations
{
    /// <inheritdoc />
    public partial class ParteCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "centro_de_Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero_Entrada = table.Column<int>(type: "int", nullable: false),
                    Num_Mesa = table.Column<int>(type: "int", nullable: false),
                    Estado_Entrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado_Pago = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centro_de_Pedidos", x => x.PedidoId);
                });

            migrationBuilder.CreateTable(
                name: "reservacion",
                columns: table => new
                {
                    ReservacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservacion", x => x.ReservacionId);
                });

            migrationBuilder.CreateTable(
                name: "centro_Detalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    Nombre_Produc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Centro_de_Pedidos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centro_Detalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_centro_Detalle_centro_de_Pedidos_Centro_de_Pedidos",
                        column: x => x.Centro_de_Pedidos,
                        principalTable: "centro_de_Pedidos",
                        principalColumn: "PedidoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_centro_Detalle_Centro_de_Pedidos",
                table: "centro_Detalle",
                column: "Centro_de_Pedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "centro_Detalle");

            migrationBuilder.DropTable(
                name: "reservacion");

            migrationBuilder.DropTable(
                name: "centro_de_Pedidos");
        }
    }
}
