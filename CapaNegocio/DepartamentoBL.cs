using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class DepartamentoBL
    {
        public List<DepartamentoCLS> listarDepartamento()
        {
            DepartamentoDAL obj = new DepartamentoDAL();
            return obj.listarDepartamento();
        }

        public int guardarDepartamentos(DepartamentoCLS oDepartamentoCLS)
        {
            DepartamentoDAL obj = new DepartamentoDAL();
            return obj.guardarDepartamentos(oDepartamentoCLS);
        }

        public DepartamentoCLS recuperarDepartamento(int registro)
        {
            DepartamentoDAL obj = new DepartamentoDAL();
            return obj.recuperarDepartamento(registro);
        }
    }
}
