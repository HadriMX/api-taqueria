using ApiTaqueria.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTaqueria.Persistence
{
    public partial class TaqueriaContext : DbContext
    {
        public TaqueriaContext()
        {
        }

        public TaqueriaContext(DbContextOptions<TaqueriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asistencias> Asistencias { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<DetalleOrden> DetalleOrden { get; set; }
        public virtual DbSet<Detallecompra> Detallecompra { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Mermas> Mermas { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<ProductosProveedores> ProductosProveedores { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Tacos> Tacos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Asistencias>(entity =>
            {
                entity.HasKey(e => e.IdAsistencia);

                entity.ToTable("asistencias");

                entity.Property(e => e.IdAsistencia).HasColumnName("ID_asistencia");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.HoraEntrada).HasColumnName("hora_entrada");

                entity.Property(e => e.HoraSalida).HasColumnName("hora_salida");

                entity.Property(e => e.IdEmpleado).HasColumnName("ID_empleado");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Asistencias)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asistencias_empleados");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Compras>(entity =>
            {
                entity.HasKey(e => e.IdCompra);

                entity.ToTable("compras");

                entity.Property(e => e.IdCompra).HasColumnName("ID_compra");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.NombreProducto).HasColumnName("Nombre_producto");

                entity.Property(e => e.Proveedor).HasColumnName("proveedor");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("money");

                entity.HasOne(d => d.NombreProductoNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.NombreProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_compras_productos");

                entity.HasOne(d => d.ProveedorNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.Proveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_compras_proveedores");
            });

            modelBuilder.Entity<DetalleOrden>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("detalle_orden");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrden).HasColumnName("id_orden");

                entity.Property(e => e.IdTaco).HasColumnName("id_taco");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnName("precio_unitario")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.DetalleOrden)
                    .HasForeignKey(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_orden_ordenes");

                entity.HasOne(d => d.IdTacoNavigation)
                    .WithMany(p => p.DetalleOrden)
                    .HasForeignKey(d => d.IdTaco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_orden_tacos");
            });

            modelBuilder.Entity<Detallecompra>(entity =>
            {
                entity.HasKey(e => e.IdDetallecompra);

                entity.ToTable("detallecompra");

                entity.Property(e => e.IdDetallecompra).HasColumnName("id_detallecompra");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdCompra).HasColumnName("id_compra");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnName("precio_unitario")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.Detallecompra)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detallecompra_compras");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.Detallecompra)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detallecompra_inventario");
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.ToTable("empleados");

                entity.Property(e => e.IdEmpleado).HasColumnName("ID_empleado");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasColumnName("apellido_1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasColumnName("apellido_2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Puesto)
                    .IsRequired()
                    .HasColumnName("puesto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salario).HasColumnType("money");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario)
                    .HasName("PK_productos");

                entity.ToTable("inventario");

                entity.Property(e => e.IdInventario).HasColumnName("ID_inventario");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdProveedor).HasColumnName("Id_proveedor");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasColumnName("Nombre_producto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("money");

                entity.Property(e => e.TipoProducto)
                    .IsRequired()
                    .HasColumnName("Tipo_producto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadMedida)
                    .IsRequired()
                    .HasColumnName("Unidad_medida")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_productos_proveedores");
            });

            modelBuilder.Entity<Mermas>(entity =>
            {
                entity.HasKey(e => e.IdMerma);

                entity.ToTable("mermas");

                entity.Property(e => e.IdMerma).HasColumnName("ID_merma");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdProducto).HasColumnName("ID_producto");

                entity.Property(e => e.PrecioKilo)
                    .HasColumnName("precio_kilo")
                    .HasColumnType("money");

                entity.Property(e => e.UnidadMedida)
                    .IsRequired()
                    .HasColumnName("Unidad_medida")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Mermas)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mermas_productos");
            });

            modelBuilder.Entity<Ordenes>(entity =>
            {
                entity.HasKey(e => e.IdOrden);

                entity.ToTable("ordenes");

                entity.Property(e => e.IdOrden).HasColumnName("ID_orden");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasColumnName("estatus")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdEmpleado).HasColumnName("ID_empleado");

                entity.Property(e => e.TipoPedido)
                    .IsRequired()
                    .HasColumnName("tipo_pedido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ordenes_empleados");

                entity.Property(e => e.NumMesa).HasColumnName("num_mesa");
            });

            modelBuilder.Entity<ProductosProveedores>(entity =>
            {
                entity.HasKey(e => new { e.IdProveedor, e.Producto });

                entity.ToTable("productos_proveedores");

                entity.Property(e => e.IdProveedor).HasColumnName("ID_proveedor");

                entity.Property(e => e.Producto).HasColumnName("producto");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.ProductosProveedores)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_productos_proveedores_proveedores");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.ProductosProveedores)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_productos_proveedores_inventario");
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.ToTable("proveedores");

                entity.Property(e => e.IdProveedor).HasColumnName("ID_proveedor");

                entity.Property(e => e.DiasSurte)
                    .IsRequired()
                    .HasColumnName("Dias_surte")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NombreContacto)
                    .IsRequired()
                    .HasColumnName("Nombre_contacto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreFiscal)
                    .IsRequired()
                    .HasColumnName("Nombre_fiscal")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Tacos>(entity =>
            {
                entity.HasKey(e => e.IdTacos);

                entity.ToTable("tacos");

                entity.Property(e => e.IdTacos).HasColumnName("ID_tacos");

                entity.Property(e => e.Ingredientes)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("money");
            });
        }
    }
}
