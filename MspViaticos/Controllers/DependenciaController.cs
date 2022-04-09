using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MspViaticos.Controllers
{
    public class DependenciaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<DependenciaCLS> listarDependencias()
        {
            DependenciaBL obj = new DependenciaBL();
            return obj.listarDependencias();
        }

        public int guardarDependencia(DependenciaCLS oDependenciaCLS)
        {
            DependenciaBL obj = new DependenciaBL();
            return obj.guardarDependencia(oDependenciaCLS);
        }

        public DependenciaCLS recuperarDependencia(int registro)
        {
            DependenciaBL obj = new DependenciaBL();
            return obj.recuperarDependencia(registro);
        }
    }
}
