using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ConfiguracionBL
    {
        public List<ConfiguracionCLS> listarConfiguracion()
        {
            ConfiguracionDAL obj = new ConfiguracionDAL();
            return obj.listarConfiguracion();
        }
    }
}
