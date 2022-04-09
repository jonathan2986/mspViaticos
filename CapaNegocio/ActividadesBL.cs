using CapaEntidad;
using CapaDatos;
namespace CapaNegocio
{
    public class ActividadesBL
    {
        public List<ActividadesCLS> listarActividades()
        {
            ActividadesDAL obj = new ActividadesDAL();

            return obj.listarActividades();
        }

        public int guardarActividades(ActividadesCLS oActividadesCLS)
        {
            ActividadesDAL obj = new ActividadesDAL();
            return obj.guardarActividades(oActividadesCLS);
        }

        public ActividadesCLS recuperarActividad(int registro)
        {
            ActividadesDAL obj = new ActividadesDAL();
            return obj.recuperarActividad(registro);
        }

        public List<ActividadesCLS> filtrarActividad(string nombreActividad)
        {
            ActividadesDAL obj = new ActividadesDAL();
            return obj.filtrarActividad(nombreActividad);
        }

        public int eliminarActividad(int registro)
        {
            ActividadesDAL obj = new ActividadesDAL();
            return obj.eliminarActividad(registro);
        }
    }
}