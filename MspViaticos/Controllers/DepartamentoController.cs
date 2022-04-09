using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MspViaticos.Controllers
{
    public class DepartamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<DepartamentoCLS> listarDepartamento()
        {
            DepartamentoBL obj = new DepartamentoBL();
            return obj.listarDepartamento();
        }

        public int guardarDepartamentos(DepartamentoCLS oDepartamentoCLS)
        {
            DepartamentoBL obj = new DepartamentoBL();
            return obj.guardarDepartamentos(oDepartamentoCLS);
        }

        public DepartamentoCLS recuperarDepartamento(int registro)
        {
            DepartamentoBL obj = new DepartamentoBL();
            return obj.recuperarDepartamento(registro);
        }
    }
}
