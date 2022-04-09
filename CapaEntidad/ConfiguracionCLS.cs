using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ConfiguracionCLS
    {
        public int registro { get; set; }
        public string desdePagoDiaSueldo { get; set; }

        public string desdePagoDiaSueldoAMPM { get; set; }

        public string hastaPagoDiaSueldo { get; set; }

        public string hastaPagoDiaSueldoAMPM { get; set; }

        public decimal factorDiasLaboralesMes { get; set; }

        public string desdeDesayuno { get; set; }

        public string desdeDesayunoAMPM { get; set; }

        public string hastaDesayuno { get; set; }

        public string hastaDesayunoAMPM { get; set; }

        public decimal porcientoDesayuno { get; set; }

        public string desdeAlmuerzo { get; set; }

        public string desdeAlmuerzoAMPM { get; set; }

        public string hastaAlmuerzo { get; set; }

        public string hastaAlmuerzoAMPM { get; set; }

        public decimal porcientoAlmuerzo { get; set; }

        public string desdeCena { get; set; }

        public string desdeCenaAMPM { get; set; }

        public string hastaCena { get; set; }

        public string hastaCenaAMPM { get; set; }

        public decimal porcientoCena { get; set; }

        public decimal porcientoAlojamiento { get; set; }

        public string usuario { get; set; }

        public DateTime digitadoFecha { get; set; }

        public string digitadoHora { get; set; }

        public string usuarioModificado { get; set; }

        public DateTime modificadoFecha { get; set; }

        public string modificadoHora { get; set; }
    }
}
