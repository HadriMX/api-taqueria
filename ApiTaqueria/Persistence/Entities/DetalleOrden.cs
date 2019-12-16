using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class DetalleOrden
    {
        public int IdOrden { get; set; }
        public int IdTaco { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Nota { get; set; }
        public int Id { get; set; }

        public virtual Ordenes IdOrdenNavigation { get; set; }
        public virtual Tacos IdTacoNavigation { get; set; }
    }
}
