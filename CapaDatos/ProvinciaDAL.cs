using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ProvinciaDAL : CadenaDAL
    {
        public List<ProvinciaCLS> listarProvincias()
        {
            List<ProvinciaCLS> lista = null;

            using (SqlConnection cn = new(cadena))
            {
                var query = "SELECT * FROM uvwProvincias ";
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<ProvinciaCLS>();
                            ProvinciaCLS oProvinciaCLS;
                            int posRegistro = drd.GetOrdinal("Registro");
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posNombre = drd.GetOrdinal("Nombre");
                            while (drd.Read())
                            {
                                oProvinciaCLS = new ProvinciaCLS();
                                oProvinciaCLS.registro = drd.GetInt32(posRegistro);
                                oProvinciaCLS.codigo = drd.IsDBNull(posCodigo) ? "" : drd.GetString(posCodigo);
                                oProvinciaCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);


                                lista.Add(oProvinciaCLS);

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    lista = null;

                    throw ex;
                }
            }


            return lista;

        }
    }
}
