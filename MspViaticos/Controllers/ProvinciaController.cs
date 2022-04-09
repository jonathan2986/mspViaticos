using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MspViaticos.Controllers
{
    public class ProvinciaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<ProvinciaCLS> listarProvincias()
        {
            ProvinciaBL obj = new ProvinciaBL();
            return obj.listarProvincias();
        }
    }
}
