using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class Mermas
    {
        public int IdMerma { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PrecioKilo { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Inventario IdProductoNavigation { get; set; }
    }
}
