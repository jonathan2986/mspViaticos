using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class GrupoBL
    {
        public List<GrupoCLS> listarGrupos()
        {
            GrupoDAL obj = new GrupoDAL();
            return obj.listarGrupos();
        }

        public int guardarGrupos(GrupoCLS oGrupoCLS)
        {
            GrupoDAL obj = new GrupoDAL();
            return obj.guardarGrupos(oGrupoCLS);
        }
    }
}
