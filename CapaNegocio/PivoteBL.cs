using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class PivoteBL
    {
        public List<PivoteCLS> listarPivotes()
        {
            PivoteDAL obj = new PivoteDAL();
            return obj.listarPivotes();
        }

        public CargoComboGrupoCLS listarGrupos()
        {
            PivoteDAL obj = new PivoteDAL();
            return obj.listarGrupos();
        }

        public int guardarPivotes(PivoteCLS oPivoteCLS)
        {
            PivoteDAL obj = new PivoteDAL();
            return obj.guardarPivotes(oPivoteCLS);
        }
    }
}
