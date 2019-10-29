using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class Empleados
    {
        public Empleados()
        {
            Ordenes = new HashSet<Ordenes>();
        }

        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Puesto { get; set; }
        public decimal Salario { get; set; }
        public string Estatus { get; set; }

        public virtual ICollection<Ordenes> Ordenes { get; set; }
    }
}
