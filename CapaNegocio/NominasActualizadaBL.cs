using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NominasActualizadaBL
    {
        public List<NominasActualizadaCLS> listarNominasActualizadas()
        {
            NominasActualizadaDAL obj = new NominasActualizadaDAL();
            return obj.listarNominasActualizadas();
        }

        public int guardarNominaActualizada(NominasActualizadaCLS oNominasActualizadaCLS)
        {
            NominasActualizadaDAL obj = new NominasActualizadaDAL();
            return obj.guardarNominaActualizada(oNominasActualizadaCLS);
        }

        public NominasActualizadaCLS recuperarNominasActualizada(int registro)
        {
            NominasActualizadaDAL obj = new NominasActualizadaDAL();
            return obj.recuperarNominasActualizada(registro);
        }
    }
}
