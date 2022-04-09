using Microsoft.AspNetCore.Mvc;
using System;
using CapaNegocio;
using CapaEntidad;
namespace MspViaticos.Controllers
{
    public class ActividadesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<ActividadesCLS> listarActividades()
        {
            ActividadesBL obj = new ActividadesBL();
            return obj.listarActividades();
        }

        public int GuardarDatos(ActividadesCLS oActividadesCLS)
        {
            ActividadesBL obj = new ActividadesBL();
            return obj.guardarActividades(oActividadesCLS);
        }

        public ActividadesCLS recuperarActividad(int registro)
        {
            ActividadesBL obj = new ActividadesBL();
            return obj.recuperarActividad(registro);
        }
        public List<ActividadesCLS> filtrarActividad(string nombreActividad)
        {
            ActividadesBL obj = new ActividadesBL();
            return obj.filtrarActividad(nombreActividad);
        }

        public int eliminarActividad(int registro)
        {
            ActividadesBL obj = new ActividadesBL();
            return obj.eliminarActividad(registro);
        }

    }
}
