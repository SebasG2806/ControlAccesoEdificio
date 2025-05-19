using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAccesoEdificio.Entities
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int ZonaAcceso { get; set; }
    }
}
