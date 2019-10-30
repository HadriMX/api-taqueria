using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class Tacos
    {
        public Tacos()
        {
            DetalleOrden = new HashSet<DetalleOrden>();
        }

        public int IdTacos { get; set; }
        public int Ingredientes { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public virtual Inventario IngredientesNavigation { get; set; }
        public virtual ICollection<DetalleOrden> DetalleOrden { get; set; }
    }
}
