using ApiTaqueria.Persistence.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiTaqueria.Persistence
{
    public partial class TaqueriaContext : IdentityDbContext
    {
        public TaqueriaContext(DbContextOptions<TaqueriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asistencias> Asistencias { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<DetalleOrden> DetalleOrden { get; set; }
        public virtual DbSet<Detallecompra> Detallecompra { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Ingredientes> Ingredientes { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Mermas> Mermas { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<ProductosProveedores> ProductosProveedores { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Tacos> Tacos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

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
                entity.HasKey(e => new { e.IdOrden, e.IdTaco });

                entity.ToTable("detalle_orden");

                entity.Property(e => e.IdOrden).HasColumnName("id_orden");

                entity.Property(e => e.IdTaco).HasColumnName("id_taco");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

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
                entity.HasKey(e => e.IdCompra);

                entity.ToTable("detallecompra");

                entity.Property(e => e.IdCompra)
                    .HasColumnName("id_compra")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnName("precio_unitario")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithOne(p => p.Detallecompra)
                    .HasForeignKey<Detallecompra>(d => d.IdCompra)
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

            modelBuilder.Entity<Ingredientes>(entity =>
            {
                entity.HasKey(e => e.IdIngrendiente);

                entity.ToTable("ingredientes");

                entity.Property(e => e.IdIngrendiente)
                    .HasColumnName("ID_ingrendiente")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("Id_producto")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MateriaPrima).HasColumnName("materia_prima");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Ingredientes)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ingredientes_productos");

                entity.HasOne(d => d.MateriaPrimaNavigation)
                    .WithMany(p => p.Ingredientes)
                    .HasForeignKey(d => d.MateriaPrima)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ingredientes_inventario");
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
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK_productos_1");

                entity.ToTable("productos");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasColumnName("nombre_producto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("money");
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

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("money");

                entity.HasOne(d => d.IngredientesNavigation)
                    .WithMany(p => p.Tacos)
                    .HasForeignKey(d => d.Ingredientes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tacos_productos");
            });
        }
    }
}
