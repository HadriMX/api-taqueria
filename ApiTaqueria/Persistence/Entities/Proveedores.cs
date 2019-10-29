using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class Proveedores
    {
        public Proveedores()
        {
            Compras = new HashSet<Compras>();
            Inventario = new HashSet<Inventario>();
        }

        public int IdProveedor { get; set; }
        public string DiasSurte { get; set; }
        public string NombreFiscal { get; set; }
        public string NombreContacto { get; set; }
        public string Telefono { get; set; }
        public string Estatus { get; set; }

        public virtual ICollection<Compras> Compras { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}
