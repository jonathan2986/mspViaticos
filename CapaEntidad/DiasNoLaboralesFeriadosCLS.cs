using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DiasNoLaboralesFeriadosCLS
    {
        public int registro { get; set; }

        public DateTime fecha { get; set; }

        public string descripcion { get; set; }

        public byte tipo { get; set; }

        public string tipoDes { get; set; }

        public string usuario { get; set; }

        public DateTime digitadoFecha { get; set; }

        public string digitadoHora { get; set; }

        public string usuarioModificado { get; set; }

        public DateTime modificadoFecha { get; set; }

        public string modificadoHora { get; set; }
    }
}
