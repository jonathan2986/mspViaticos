using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MspViaticos.Controllers
{
    public class ViaticoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<ViaticoCLS> listarViaticos()
        {
            ViaticoBL obj = new ViaticoBL();
            return obj.listarViaticos();
        }
    }
}
