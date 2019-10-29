using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class Tacos
    {
        public int IdTacos { get; set; }
        public int Ingredientes { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public virtual Inventario IngredientesNavigation { get; set; }
    }
}
