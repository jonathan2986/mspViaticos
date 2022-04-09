using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ProvinciaTuristicaBL
    {
        public List<ProvinciaTuristicaCLS> listarProvinciaTuristica()
        {
            ProvinciaTuristicaDAL obj = new ProvinciaTuristicaDAL();
            return obj.listarProvinciaTuristica();
        }

        public ComboProvinciaCLS listarProvincias()
        {
            ProvinciaTuristicaDAL obj = new ProvinciaTuristicaDAL();
            return obj.listarProvincias();
        }

        public int guardarProvinciaTuristica(ProvinciaTuristicaCLS oProvinciaTuristicaCLS)
        {
            ProvinciaTuristicaDAL obj = new ProvinciaTuristicaDAL();
            return obj.guardarProvinciaTuristica(oProvinciaTuristicaCLS);
        }

        public ProvinciaTuristicaCLS recuperarProvinciaTuristica(int registro)
        {
            ProvinciaTuristicaDAL obj = new ProvinciaTuristicaDAL();
            return obj.recuperarProvinciaTuristica(registro);
        }
    }
}
