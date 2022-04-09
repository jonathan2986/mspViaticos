using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MspViaticos.Controllers
{
    public class NominasActualizadaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<NominasActualizadaCLS> listarNominasActualizadas()
        {
            NominasActualizadaBL obj = new NominasActualizadaBL();
            return obj.listarNominasActualizadas();
        }

        public int guardarNominaActualizada(NominasActualizadaCLS oNominasActualizadaCLS)
        {
            NominasActualizadaBL obj = new NominasActualizadaBL();
            return obj.guardarNominaActualizada(oNominasActualizadaCLS);
        }

        public NominasActualizadaCLS recuperarNominasActualizada(int registro)
        {
            NominasActualizadaBL obj = new NominasActualizadaBL();
            return obj.recuperarNominasActualizada(registro);
        }
    }
}
