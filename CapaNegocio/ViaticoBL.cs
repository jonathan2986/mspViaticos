using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ViaticoBL
    {
        public List<ViaticoCLS> listarViaticos()
        {
            ViaticoDAL obj = new ViaticoDAL();
            return obj.listarViaticos();
        }
    }
}
