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
    public class GrupoDAL : CadenaDAL
    {
        public int guardarGrupos(GrupoCLS oGrupoCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGrupos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Registro", oGrupoCLS.registro);
                        cmd.Parameters.AddWithValue("@Codigo", oGrupoCLS.codigo);
                        cmd.Parameters.AddWithValue("@Descripcion", oGrupoCLS.descripcion);
                        cmd.Parameters.AddWithValue("@Tarifa", oGrupoCLS.tarifa);
                        cmd.Parameters.AddWithValue("@Desayuno", oGrupoCLS.desayuno);
                        cmd.Parameters.AddWithValue("@Almuerzo", oGrupoCLS.almuerzo);
                        cmd.Parameters.AddWithValue("@Cena", oGrupoCLS.cena);
                        cmd.Parameters.AddWithValue("@Alojamiento", oGrupoCLS.alojamiento);
                        cmd.Parameters.AddWithValue("@Estatus", oGrupoCLS.estatus);

                        SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        rpta = cmd.ExecuteNonQuery();
                        rpta = (int)returnParameter.Value;
                        cn.Close();
                    }
                }
                catch (Exception)
                {
                    rpta = 0;
                    cn.Close();

                    throw;
                }
            }
            return rpta;
        }

        public List<GrupoCLS> listarGrupos()
        {

            List<GrupoCLS> lista = null;

            using (SqlConnection cn = new(cadena))
            {
                var query = "SELECT * FROM uvwGrupos ";
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<GrupoCLS>();
                            GrupoCLS oGrupoCLS;
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posDesc = drd.GetOrdinal("Descripcion");
                            int posTarifa = drd.GetOrdinal("Tarifa");
                            int posDesayuno = drd.GetOrdinal("Desayuno");
                            int posAlmuerzo = drd.GetOrdinal("Almuerzo");
                            int posCena = drd.GetOrdinal("Cena");
                            int posAlojamiento = drd.GetOrdinal("Alojamiento");
                            int posEstatusDescripcion = drd.GetOrdinal("EstatusDescripcion");
                            while (drd.Read())
                            {
                                oGrupoCLS = new GrupoCLS();
                                oGrupoCLS.codigo = drd.IsDBNull(posCodigo) ? "" : drd.GetString(posCodigo);
                                oGrupoCLS.descripcion = drd.IsDBNull(posDesc) ? "" : drd.GetString(posDesc);
                                oGrupoCLS.tarifa = drd.IsDBNull(posTarifa) ? 0 : drd.GetDecimal(posTarifa);
                                oGrupoCLS.desayuno = drd.IsDBNull(posDesayuno) ? 0 : drd.GetDecimal(posDesayuno);
                                oGrupoCLS.almuerzo = drd.IsDBNull(posAlmuerzo) ? 0 : drd.GetDecimal(posAlmuerzo);
                                oGrupoCLS.cena = drd.IsDBNull(posCena) ? 0 : drd.GetDecimal(posCena);
                                oGrupoCLS.alojamiento = drd.IsDBNull(posAlojamiento) ? 0 : drd.GetDecimal(posAlojamiento);
                                oGrupoCLS.estatusDescripcion = drd.IsDBNull(posEstatusDescripcion) ? "" : drd.GetString(posEstatusDescripcion);

                                lista.Add(oGrupoCLS);

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
