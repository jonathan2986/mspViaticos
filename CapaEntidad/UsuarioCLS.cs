using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class UsuarioCLS
    {
        public int registro { get; set; }
        public string codigo { get; set; }

        public string clave { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string cedula { get; set; }


        public string descripcion { get; set; }

        public byte estatus { get; set; }

        public string estatusDescripcion { get; set; }

        public string usuario { get; set; }

        public DateTime digitadoFecha { get; set; }

        public string digitadoHora { get; set; }

        public string usuarioModificado { get; set; }

        public DateTime modificadoFecha { get; set; }

        public string modificadoHora { get; set; }
    }
}
