using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ProvinciaBL
    {
        public List<ProvinciaCLS> listarProvincias()
        {
            ProvinciaDAL obj = new ProvinciaDAL();
            return obj.listarProvincias();
        }
    }
}
