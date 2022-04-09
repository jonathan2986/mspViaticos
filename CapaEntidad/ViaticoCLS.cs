using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ViaticoCLS
    {
        public int registro { get; set; }

        public int numero { get; set; }

        public DateTime fecha { get; set; }

        public string empleadoCodigo { get; set; }

        public string nombreEmpleado { get; set; }

        public string provinciaCodigo { get; set; }

        public string provinciaNombre { get; set; }

        public string dependenciaCodigo { get; set; }

        public string dependenciaNombre { get; set; }

        public string departamento { get; set; }

        public string departamentoNombre { get; set; }

        public string cargoCodigo { get; set; }

        public string cargoDescripcion { get; set; }

        public decimal sueldo { get; set; }

        public byte metodo { get; set; }

        public string metodoDescripcion { get; set; }

        public string grupoCodigo { get; set; }

        public string grupoDescripcion { get; set; }

        public decimal tarifa { get; set; }

        public string comentario { get; set; }
        
        public DateTime fechaSalida { get; set; }

        public string horaSalida { get; set; }

        public DateTime fechaRetorno { get; set; }

        public string horaRetorno { get; set; }

        public string provinciaEnviado { get; set; }

        public string provinciaEnviadoNombre { get; set; }

        public string actividadCodigo { get; set; }

        public string actividadDescripcion { get; set; }

        public decimal desayuno { get; set; }

        public decimal almuerzo { get; set; }

        public decimal cena { get; set; }

        public decimal alojamiento { get; set; }

        public decimal totalDieta { get; set; }

        public decimal transporte { get; set; }

        public decimal totalViaje { get; set; }

        public bool anulado { get; set; }

        public bool cerrado { get; set; }

        public byte estatus { get; set; }

        public string estatusDescripcion { get; set; }
 

    }
}
