using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MspViaticos.Controllers
{
    public class ProvinciaTuristicaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<ProvinciaTuristicaCLS> listarProvinciaTuristica()
        {
            ProvinciaTuristicaBL obj = new ProvinciaTuristicaBL();
            return obj.listarProvinciaTuristica();
        }

        public ComboProvinciaCLS listarProvincias()
        {
            ProvinciaTuristicaBL obj = new ProvinciaTuristicaBL();
            return obj.listarProvincias();
        }

        public int guardarProvinciaTuristica(ProvinciaTuristicaCLS oProvinciaTuristicaCLS)
        {
            ProvinciaTuristicaBL obj = new ProvinciaTuristicaBL();
            return obj.guardarProvinciaTuristica(oProvinciaTuristicaCLS);
        }

        public ProvinciaTuristicaCLS recuperarProvinciaTuristica(int registro)
        {
            ProvinciaTuristicaBL obj = new ProvinciaTuristicaBL();
            return obj.recuperarProvinciaTuristica(registro);
        }
    }
}
