using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class EmpleadoBL
    {
        public List<EmpleadoCLS> listarEmpleados()
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.listarEmpleados();
        }

        public ComboEntidadCLS listarCombos()
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.listarCombos();
        }

        public int guardarEmpleado(EmpleadoCLS oEmpleado)
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.guardarEmpleado(oEmpleado);
        }

        public EmpleadoCLS recuperarEmpleado(int registro)
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.recuperarEmpleado(registro);
        }
    }
}
