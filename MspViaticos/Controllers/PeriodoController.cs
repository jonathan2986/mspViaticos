using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MspViaticos.Controllers
{
    public class PeriodoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<PeriodoCLS> listaPeriodo()
        {
            PeriodoBL obj = new PeriodoBL();
            return obj.listaPeriodo();
        }

        public ComboEntidadCLS listarCombos()
        {
            PeriodoBL obj = new PeriodoBL();
            return obj.listarCombos();
        }

        public int guardarPeriodo(PeriodoCLS oPeriodoCLS)
        {
            PeriodoBL obj = new PeriodoBL();
            return obj.guardarPeriodo(oPeriodoCLS);
        }
    }
}
