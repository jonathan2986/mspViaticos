using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MspViaticos.Controllers
{
    public class PivoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<PivoteCLS> listarPivotes()
        {
            PivoteBL obj = new PivoteBL();
            return obj.listarPivotes();
        }

        public CargoComboGrupoCLS listarGrupos()
        {
            PivoteBL obj = new PivoteBL();
            return obj.listarGrupos();
        }

        public int guardarPivotes(PivoteCLS oPivoteCLS)
        {
            PivoteBL obj = new PivoteBL();
            return obj.guardarPivotes(oPivoteCLS);
        }
    }
}
