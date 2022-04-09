using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class DependenciaBL
    {
        public List<DependenciaCLS> listarDependencias()
        {
            DependenciaDAL obj = new DependenciaDAL();
            return obj.listarDependencias();
        }

        public int guardarDependencia(DependenciaCLS oDependenciaCLS)
        {
            DependenciaDAL obj = new DependenciaDAL();
            return obj.guardarDependencia(oDependenciaCLS);
        }

        public DependenciaCLS recuperarDependencia(int registro)
        {
            DependenciaDAL obj = new DependenciaDAL();
            return obj.recuperarDependencia(registro);
        }
    }
}
