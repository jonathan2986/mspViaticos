using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MspViaticos.Controllers
{
    public class ConfiguracionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public List<ConfiguracionCLS> listarConfiguracion()
        {
            ConfiguracionBL obj = new ConfiguracionBL();
            return obj.listarConfiguracion();
        }
    }
}
