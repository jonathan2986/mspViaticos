using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ProvinciaTuristicaCLS
    {
        public int registro { get; set; }

        public string provincia { get; set; }
        
        public string nombreProvincia { get; set; }

        public decimal porciento { get; set; }

        public string usuario { get; set; }

        public DateTime digitadoFecha { get; set; }

        public string digitadoHora { get; set; }

        public string usuarioModificado { get; set; }

        public DateTime modificadoFecha { get; set; }

        public string modificadoHora { get; set; }
    }
}
