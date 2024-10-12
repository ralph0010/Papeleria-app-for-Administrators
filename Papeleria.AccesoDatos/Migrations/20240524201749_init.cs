using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo_Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    nombreArticulo_Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut_Digitos = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion_Calle = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Direccion_Numero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Direccion_Ciudad = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Direccion_DistanciaPapeleria = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefinirTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMovimiento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefinirTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "iva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoElegidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoMovimientos_DefinirTipos_TipoElegidoId",
                        column: x => x.TipoElegidoId,
                        principalTable: "DefinirTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emaill_Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Passwordd_Password = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Passwordd_PasswordEncriptada = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApellidoUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_rols_RolId",
                        column: x => x.RolId,
                        principalTable: "rols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    IVA = table.Column<double>(type: "float", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    Recargo = table.Column<double>(type: "float", nullable: false),
                    Fecha_FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaAnulado = table.Column<bool>(type: "bit", nullable: false),
                    PrecioTotalSinIva = table.Column<double>(type: "float", nullable: false),
                    PrecioTotalConIva = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_TipoPedidos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoPedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimientosStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TipoMovimientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientosStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientosStocks_TipoMovimientos_TipoMovimientoId",
                        column: x => x.TipoMovimientoId,
                        principalTable: "TipoMovimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientosStocks_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemArticulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemArticulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemArticulo_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemArticulo_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DefinirTipos",
                columns: new[] { "Id", "TipoMovimiento" },
                values: new object[,]
                {
                    { 1, "AumentoStock" },
                    { 2, "ReduccionStock" },
                    { 3, "Traslado" }
                });

            migrationBuilder.InsertData(
                table: "TipoPedidos",
                columns: new[] { "Id", "Tipo" },
                values: new object[,]
                {
                    { 1, "PedidoComun" },
                    { 2, "PedidoExpres" }
                });

            migrationBuilder.InsertData(
                table: "iva",
                columns: new[] { "Id", "Valor" },
                values: new object[] { 1, 0.22 });

            migrationBuilder.InsertData(
                table: "rols",
                columns: new[] { "Id", "TipoRol" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "EncargadoDeposito" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Codigo_Codigo",
                table: "Articulos",
                column: "Codigo_Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_nombreArticulo_Nombre",
                table: "Articulos",
                column: "nombreArticulo_Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Direccion_Calle_Direccion_Numero_Direccion_Ciudad_Direccion_DistanciaPapeleria",
                table: "Clientes",
                columns: new[] { "Direccion_Calle", "Direccion_Numero", "Direccion_Ciudad", "Direccion_DistanciaPapeleria" });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Rut_Digitos",
                table: "Clientes",
                column: "Rut_Digitos",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemArticulo_ArticuloId",
                table: "ItemArticulo",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemArticulo_PedidoId",
                table: "ItemArticulo",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosStocks_TipoMovimientoId",
                table: "MovimientosStocks",
                column: "TipoMovimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosStocks_UsuarioId",
                table: "MovimientosStocks",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Fecha_FechaEmision_Fecha_FechaEntrega",
                table: "Pedidos",
                columns: new[] { "Fecha_FechaEmision", "Fecha_FechaEntrega" });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_TipoId",
                table: "Pedidos",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoMovimientos_Nombre",
                table: "TipoMovimientos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoMovimientos_TipoElegidoId",
                table: "TipoMovimientos",
                column: "TipoElegidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Emaill_Email",
                table: "Usuarios",
                column: "Emaill_Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NombreUsuario_ApellidoUsuario",
                table: "Usuarios",
                columns: new[] { "NombreUsuario", "ApellidoUsuario" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Passwordd_Password_Passwordd_PasswordEncriptada",
                table: "Usuarios",
                columns: new[] { "Passwordd_Password", "Passwordd_PasswordEncriptada" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemArticulo");

            migrationBuilder.DropTable(
                name: "iva");

            migrationBuilder.DropTable(
                name: "MovimientosStocks");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "TipoMovimientos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoPedidos");

            migrationBuilder.DropTable(
                name: "DefinirTipos");

            migrationBuilder.DropTable(
                name: "rols");
        }
    }
}
