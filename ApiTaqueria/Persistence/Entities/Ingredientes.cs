using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class Ingredientes
    {
        public int IdProducto { get; set; }
        public int MateriaPrima { get; set; }
        public int Cantidad { get; set; }
        public int IdIngrendiente { get; set; }

        public virtual Productos IdProductoNavigation { get; set; }
        public virtual Inventario MateriaPrimaNavigation { get; set; }
    }
}
