using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EmpleadoCLS
    {
        public int registro { get; set; }

        public string codigo { get; set; }

        public string nombre { get; set; }

        public string cedula { get; set; }

        public string provincia { get; set; }

        public string provinciaNombre { get; set; }

        public string dependencia { get; set; }

        public string dependenciaNombre { get; set; }

        public string departamento { get; set; }

        public string departamentoNombre { get; set; }

        public string cargo { get; set; }

        public string cargoDescripcion { get; set; }

        public decimal sueldo { get; set; }

        public byte estatus { get; set; }

        public string estatusDescripcion { get; set; }
    }
}
