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
    public class DiasNoLaboralesFeriadosDAL : CadenaDAL
    {

        public int guardarDiasNoLaboralesFeriados(DiasNoLaboralesFeriadosCLS oDiasNoLaboralesFeriadosCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspDiasNoLaboralesFeriados", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Registro", oDiasNoLaboralesFeriadosCLS.registro);
                        cmd.Parameters.AddWithValue("@Fecha", oDiasNoLaboralesFeriadosCLS.fecha);
                        cmd.Parameters.AddWithValue("@Descripcion", oDiasNoLaboralesFeriadosCLS.descripcion);
                        cmd.Parameters.AddWithValue("@Tipo", oDiasNoLaboralesFeriadosCLS.tipo);

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
        public List<DiasNoLaboralesFeriadosCLS> listaDiasNoLaboralesFeriados()
        {
            List<DiasNoLaboralesFeriadosCLS> lista = null;

            using (SqlConnection cn = new(cadena))
            {
                var query = "SELECT * FROM uvwDiasNoLaboralesFeriados ";
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<DiasNoLaboralesFeriadosCLS>();
                            DiasNoLaboralesFeriadosCLS oDiasNoLaboralesFeriadosCLS;
                            int posFecha = drd.GetOrdinal("Fecha");
                            int posDescripcion = drd.GetOrdinal("Descripcion");
                            int posTipoDes = drd.GetOrdinal("TipoDescripcion");
                            while (drd.Read())
                            {
                                oDiasNoLaboralesFeriadosCLS = new DiasNoLaboralesFeriadosCLS();
                                oDiasNoLaboralesFeriadosCLS.fecha = drd.GetDateTime(posFecha);
                                oDiasNoLaboralesFeriadosCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                                oDiasNoLaboralesFeriadosCLS.tipoDes = drd.IsDBNull(posTipoDes) ? "" : drd.GetString(posTipoDes);

                                lista.Add(oDiasNoLaboralesFeriadosCLS);

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
