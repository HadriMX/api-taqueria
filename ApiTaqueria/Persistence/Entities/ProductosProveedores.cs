using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class ProductosProveedores
    {
        public int IdProveedor { get; set; }
        public int Producto { get; set; }

        public virtual Proveedores IdProveedorNavigation { get; set; }
        public virtual Inventario ProductoNavigation { get; set; }
    }
}
