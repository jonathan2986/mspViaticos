using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MspViaticos.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<EmpleadoCLS> listarEmpleados()
        {
            EmpleadoBL obj = new EmpleadoBL();
            return obj.listarEmpleados();
        }

        public ComboEntidadCLS listarCombos()
        {
            EmpleadoBL obj = new EmpleadoBL();
            return obj.listarCombos();
        }

        public int guardarEmpleado(EmpleadoCLS oEmpleado)
        {
            EmpleadoBL obj = new EmpleadoBL();
            return obj.guardarEmpleado(oEmpleado);
        }

        public EmpleadoCLS recuperarEmpleado(int registro)
        {
            EmpleadoBL obj = new EmpleadoBL();
            return obj.recuperarEmpleado(registro);
        }
    }
}
