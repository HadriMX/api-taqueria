using System;
using System.Collections.Generic;

namespace ApiTaqueria.Persistence.Entities
{
    public partial class Asistencias
    {
        public int IdEmpleado { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public DateTime Fecha { get; set; }
        public int IdAsistencia { get; set; }

        public virtual Empleados IdEmpleadoNavigation { get; set; }
    }
}
