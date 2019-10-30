using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class Productos
    {
        public Productos()
        {
            Ingredientes = new HashSet<Ingredientes>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }

        public virtual ICollection<Ingredientes> Ingredientes { get; set; }
    }
}
