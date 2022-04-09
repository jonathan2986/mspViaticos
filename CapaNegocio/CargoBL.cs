using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CargoBL
    {
        public List<CargoCLS> listarCargos()
        {
            CargoDAL obj = new CargoDAL();
            return obj.listarCargos();
        }

        public CargoComboGrupoCLS listarGrupos()
        {
            CargoDAL obj = new CargoDAL();
            return obj.listarGrupos();
        }

        public int guardarCargo(CargoCLS oCargoCLS)
        {
            CargoDAL obj = new CargoDAL();
            return obj.guardarCargo(oCargoCLS);
        }

        public CargoCLS recuperarCargoo(int registro)
        {
            CargoDAL obj = new CargoDAL();
            return obj.recuperarCargoo(registro);
        }
    }
}
