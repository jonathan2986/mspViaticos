using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MspViaticos.Controllers
{
    public class GrupoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public List<GrupoCLS> listarGrupos()
        {
            GrupoBL obj = new GrupoBL();
            return obj.listarGrupos();
        }

        public int guardarGrupos(GrupoCLS oGrupoCLS)
        {
            GrupoBL obj = new GrupoBL();
            return obj.guardarGrupos(oGrupoCLS);
        }
    }
}
