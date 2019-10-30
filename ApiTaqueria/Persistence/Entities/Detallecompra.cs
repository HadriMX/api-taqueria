using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class Detallecompra
    {
        public int IdCompra { get; set; }
        public int Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public virtual Compras IdCompraNavigation { get; set; }
        public virtual Inventario ProductoNavigation { get; set; }
    }
}
