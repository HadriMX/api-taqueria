using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class Inventario
    {
        public Inventario()
        {
            Compras = new HashSet<Compras>();
            Mermas = new HashSet<Mermas>();
            Tacos = new HashSet<Tacos>();
        }

        public int IdInventario { get; set; }
        public string TipoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public int IdProveedor { get; set; }
        public string Estatus { get; set; }

        public virtual Proveedores IdProveedorNavigation { get; set; }
        public virtual ICollection<Compras> Compras { get; set; }
        public virtual ICollection<Mermas> Mermas { get; set; }
        public virtual ICollection<Tacos> Tacos { get; set; }
    }
}
