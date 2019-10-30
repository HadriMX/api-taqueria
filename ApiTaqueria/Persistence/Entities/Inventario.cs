using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class Inventario
    {
        public Inventario()
        {
            Compras = new HashSet<Compras>();
            Detallecompra = new HashSet<Detallecompra>();
            Ingredientes = new HashSet<Ingredientes>();
            Mermas = new HashSet<Mermas>();
            ProductosProveedores = new HashSet<ProductosProveedores>();
            Tacos = new HashSet<Tacos>();
        }

        public int IdInventario { get; set; }
        public string TipoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public int IdProveedor { get; set; }
        public string Estatus { get; set; }

        public virtual Proveedores IdProveedorNavigation { get; set; }
        public virtual ICollection<Compras> Compras { get; set; }
        public virtual ICollection<Detallecompra> Detallecompra { get; set; }
        public virtual ICollection<Ingredientes> Ingredientes { get; set; }
        public virtual ICollection<Mermas> Mermas { get; set; }
        public virtual ICollection<ProductosProveedores> ProductosProveedores { get; set; }
        public virtual ICollection<Tacos> Tacos { get; set; }
    }
}
