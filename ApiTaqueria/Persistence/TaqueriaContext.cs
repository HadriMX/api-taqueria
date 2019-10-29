using ApiTaqueria.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTaqueria.Persistence
{
    public class TaqueriaContext : DbContext
    {
        public TaqueriaContext(DbContextOptions<TaqueriaContext> options) : base(options)
        {
        }

        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Mermas> Mermas { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Tacos> Tacos { get; set; }

        // Unable to generate entity type for table 'dbo.asistencias'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.detalle_orden'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.detallecompra'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ingredientes'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.productos_proveedores'. Please see the warning messages.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Compras>(entity =>
            {
                entity.HasKey(e => e.IdCompra);

                entity.ToTable("compras");

                entity.Property(e => e.IdCompra)
                    .HasColumnName("ID_compra")
                    .ValueGeneratedNever();

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

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.ToTable("empleados");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnName("ID_empleado")
                    .ValueGeneratedNever();

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

                entity.Property(e => e.IdInventario)
                    .HasColumnName("ID_inventario")
                    .ValueGeneratedNever();

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

                entity.Property(e => e.IdMerma)
                    .HasColumnName("ID_merma")
                    .ValueGeneratedNever();

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

                entity.Property(e => e.IdOrden)
                    .HasColumnName("ID_orden")
                    .ValueGeneratedNever();

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

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasColumnName("nombre_producto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.ToTable("proveedores");

                entity.Property(e => e.IdProveedor)
                    .HasColumnName("ID_proveedor")
                    .ValueGeneratedNever();

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

                entity.Property(e => e.IdTacos)
                    .HasColumnName("ID_tacos")
                    .ValueGeneratedNever();

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
