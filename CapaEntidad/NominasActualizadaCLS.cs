using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class NominasActualizadaCLS
    {
        public int registro { get; set; }

        public int anio { get; set; }

        public int mes { get; set; }

        public string mesDescripcion { get; set; }

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
