using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class Ordenes
    {
        public int IdOrden { get; set; }
        public string TipoPedido { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public virtual Empleados IdEmpleadoNavigation { get; set; }
    }
}
