using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MspViaticos.Controllers
{
    public class CargoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<CargoCLS> listarCargos()
        {
            CargoBL obj = new CargoBL();
            return obj.listarCargos();
        }

        public CargoComboGrupoCLS listarGrupos()
        {
            CargoBL obj = new CargoBL();
            return obj.listarGrupos();
        }

        public int guardarCargo(CargoCLS oCargoCLS)
        {
            CargoBL obj = new CargoBL();
            return obj.guardarCargo(oCargoCLS);
        }

        public CargoCLS recuperarCargo(int registro)
        {
            CargoBL obj = new CargoBL();
            return obj.recuperarCargoo(registro);
        }
    }
}
