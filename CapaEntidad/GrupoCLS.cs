using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class GrupoCLS
    {
        public int registro { get; set; }

        public string codigo { get; set; }

        public string descripcion { get; set; }

        public decimal tarifa { get; set; }

        public decimal desayuno { get; set; }

        public decimal almuerzo { get; set; }

        public decimal cena { get; set; }

        public decimal alojamiento { get; set; }

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
