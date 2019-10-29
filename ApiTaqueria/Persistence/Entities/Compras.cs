using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class Compras
    {
        public int IdCompra { get; set; }
        public int NombreProducto { get; set; }
        public int Proveedor { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Inventario NombreProductoNavigation { get; set; }
        public virtual Proveedores ProveedorNavigation { get; set; }
    }
}
