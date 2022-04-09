using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class DiasNoLaboralesFeriadosBL
    {
        public List<DiasNoLaboralesFeriadosCLS> listaDiasNoLaboralesFeriados()
        {
            DiasNoLaboralesFeriadosDAL obj = new DiasNoLaboralesFeriadosDAL();
            return obj.listaDiasNoLaboralesFeriados();
        }
        public int guardarDiasNoLaboralesFeriados(DiasNoLaboralesFeriadosCLS oDiasNoLaboralesFeriadosCLS)
        {
            DiasNoLaboralesFeriadosDAL obj = new DiasNoLaboralesFeriadosDAL();
            return obj.guardarDiasNoLaboralesFeriados(oDiasNoLaboralesFeriadosCLS);
        }
    }
}
