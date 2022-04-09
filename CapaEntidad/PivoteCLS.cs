using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PivoteCLS
    {
        public int registro { get; set; }

        public string desdeGrupo { get; set; }

        public string desdeGrupoDescripcion { get; set; }

        public string hastaGrupo { get; set; }

        public string hastaGrupoDescripcion { get; set; }

        public bool desayuno { get; set; }

        public bool almuerzo { get; set; }

        public bool cena { get; set; }

        public bool alojamiento { get; set; }

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
