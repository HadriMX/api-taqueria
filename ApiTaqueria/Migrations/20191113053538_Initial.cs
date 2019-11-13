using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiTaqueria.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    ID_empleado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    apellido_1 = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    apellido_2 = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    telefono = table.Column<string>(maxLength: 10, nullable: false),
                    puesto = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Salario = table.Column<decimal>(type: "money", nullable: false),
                    Estatus = table.Column<string>(unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.ID_empleado);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id_producto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre_producto = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    precio = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos_1", x => x.id_producto);
                });

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    ID_proveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dias_surte = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Nombre_fiscal = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Nombre_contacto = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Estatus = table.Column<string>(unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.ID_proveedor);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asistencias",
                columns: table => new
                {
                    ID_asistencia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_empleado = table.Column<int>(nullable: false),
                    hora_entrada = table.Column<TimeSpan>(nullable: false),
                    hora_salida = table.Column<TimeSpan>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asistencias", x => x.ID_asistencia);
                    table.ForeignKey(
                        name: "FK_asistencias_empleados",
                        column: x => x.ID_empleado,
                        principalTable: "empleados",
                        principalColumn: "ID_empleado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ordenes",
                columns: table => new
                {
                    ID_orden = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tipo_pedido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ID_empleado = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    total = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenes", x => x.ID_orden);
                    table.ForeignKey(
                        name: "FK_ordenes_empleados",
                        column: x => x.ID_empleado,
                        principalTable: "empleados",
                        principalColumn: "ID_empleado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventario",
                columns: table => new
                {
                    ID_inventario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo_producto = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Nombre_producto = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Unidad_medida = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Id_proveedor = table.Column<int>(nullable: false),
                    Estatus = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.ID_inventario);
                    table.ForeignKey(
                        name: "FK_productos_proveedores",
                        column: x => x.Id_proveedor,
                        principalTable: "proveedores",
                        principalColumn: "ID_proveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    ID_compra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre_producto = table.Column<int>(nullable: false),
                    proveedor = table.Column<int>(nullable: false),
                    total = table.Column<decimal>(type: "money", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compras", x => x.ID_compra);
                    table.ForeignKey(
                        name: "FK_compras_productos",
                        column: x => x.Nombre_producto,
                        principalTable: "inventario",
                        principalColumn: "ID_inventario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_compras_proveedores",
                        column: x => x.proveedor,
                        principalTable: "proveedores",
                        principalColumn: "ID_proveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ingredientes",
                columns: table => new
                {
                    ID_ingrendiente = table.Column<int>(nullable: false),
                    Id_producto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    materia_prima = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredientes", x => x.ID_ingrendiente);
                    table.ForeignKey(
                        name: "FK_ingredientes_productos",
                        column: x => x.Id_producto,
                        principalTable: "productos",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ingredientes_inventario",
                        column: x => x.materia_prima,
                        principalTable: "inventario",
                        principalColumn: "ID_inventario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mermas",
                columns: table => new
                {
                    ID_merma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_producto = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Unidad_medida = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    precio_kilo = table.Column<decimal>(type: "money", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mermas", x => x.ID_merma);
                    table.ForeignKey(
                        name: "FK_mermas_productos",
                        column: x => x.ID_producto,
                        principalTable: "inventario",
                        principalColumn: "ID_inventario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "productos_proveedores",
                columns: table => new
                {
                    ID_proveedor = table.Column<int>(nullable: false),
                    producto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos_proveedores", x => new { x.ID_proveedor, x.producto });
                    table.ForeignKey(
                        name: "FK_productos_proveedores_proveedores",
                        column: x => x.ID_proveedor,
                        principalTable: "proveedores",
                        principalColumn: "ID_proveedor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productos_proveedores_inventario",
                        column: x => x.producto,
                        principalTable: "inventario",
                        principalColumn: "ID_inventario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tacos",
                columns: table => new
                {
                    ID_tacos = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ingredientes = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    precio = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tacos", x => x.ID_tacos);
                    table.ForeignKey(
                        name: "FK_tacos_productos",
                        column: x => x.Ingredientes,
                        principalTable: "inventario",
                        principalColumn: "ID_inventario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detallecompra",
                columns: table => new
                {
                    id_compra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Producto = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    precio_unitario = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallecompra", x => x.id_compra);
                    table.ForeignKey(
                        name: "FK_detallecompra_compras",
                        column: x => x.id_compra,
                        principalTable: "compras",
                        principalColumn: "ID_compra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detallecompra_inventario",
                        column: x => x.Producto,
                        principalTable: "inventario",
                        principalColumn: "ID_inventario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detalle_orden",
                columns: table => new
                {
                    id_orden = table.Column<int>(nullable: false),
                    id_taco = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    precio_unitario = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_orden", x => new { x.id_orden, x.id_taco });
                    table.ForeignKey(
                        name: "FK_detalle_orden_ordenes",
                        column: x => x.id_orden,
                        principalTable: "ordenes",
                        principalColumn: "ID_orden",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detalle_orden_tacos",
                        column: x => x.id_taco,
                        principalTable: "tacos",
                        principalColumn: "ID_tacos",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_asistencias_ID_empleado",
                table: "asistencias",
                column: "ID_empleado");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_compras_Nombre_producto",
                table: "compras",
                column: "Nombre_producto");

            migrationBuilder.CreateIndex(
                name: "IX_compras_proveedor",
                table: "compras",
                column: "proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_id_taco",
                table: "detalle_orden",
                column: "id_taco");

            migrationBuilder.CreateIndex(
                name: "IX_detallecompra_Producto",
                table: "detallecompra",
                column: "Producto");

            migrationBuilder.CreateIndex(
                name: "IX_ingredientes_Id_producto",
                table: "ingredientes",
                column: "Id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_ingredientes_materia_prima",
                table: "ingredientes",
                column: "materia_prima");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_Id_proveedor",
                table: "inventario",
                column: "Id_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_mermas_ID_producto",
                table: "mermas",
                column: "ID_producto");

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_ID_empleado",
                table: "ordenes",
                column: "ID_empleado");

            migrationBuilder.CreateIndex(
                name: "IX_productos_proveedores_producto",
                table: "productos_proveedores",
                column: "producto");

            migrationBuilder.CreateIndex(
                name: "IX_tacos_Ingredientes",
                table: "tacos",
                column: "Ingredientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asistencias");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "detalle_orden");

            migrationBuilder.DropTable(
                name: "detallecompra");

            migrationBuilder.DropTable(
                name: "ingredientes");

            migrationBuilder.DropTable(
                name: "mermas");

            migrationBuilder.DropTable(
                name: "productos_proveedores");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ordenes");

            migrationBuilder.DropTable(
                name: "tacos");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "inventario");

            migrationBuilder.DropTable(
                name: "proveedores");
        }
    }
}
