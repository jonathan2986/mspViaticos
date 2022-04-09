using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MspViaticos.Controllers
{
    public class DiasNoLaboralesFeriadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<DiasNoLaboralesFeriadosCLS> listaDiasNoLaboralesFeriados()
        {
            DiasNoLaboralesFeriadosBL obj = new DiasNoLaboralesFeriadosBL();
            return obj.listaDiasNoLaboralesFeriados();
        }

        public int guardarDiasNoLaboralesFeriados(DiasNoLaboralesFeriadosCLS oDiasNoLaboralesFeriadosCLS)
        {
            DiasNoLaboralesFeriadosBL obj = new DiasNoLaboralesFeriadosBL();
            return obj.guardarDiasNoLaboralesFeriados(oDiasNoLaboralesFeriadosCLS);
        }
    }
}
