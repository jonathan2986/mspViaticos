using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class PeriodoBL
    {
        public List<PeriodoCLS> listaPeriodo()
        {
            PeriodoDAL obj = new PeriodoDAL();
            return obj.listaPeriodo();
        }

        public ComboEntidadCLS listarCombos()
        {
            PeriodoDAL obj = new PeriodoDAL();
            return obj.listarCombos();
        }

        public int guardarPeriodo(PeriodoCLS oPeriodoCLS)
        {
            PeriodoDAL obj = new PeriodoDAL();
            return obj.guardarPeriodo(oPeriodoCLS);
        }
    }
}
