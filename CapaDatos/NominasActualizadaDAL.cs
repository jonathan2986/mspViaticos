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
    public class NominasActualizadaDAL : CadenaDAL
    {
        public List<NominasActualizadaCLS> listarNominasActualizadas()
        {
            List<NominasActualizadaCLS> lista = null;

            using (SqlConnection cn = new(cadena))
            {
                var query = "SELECT * FROM uvwNominasActualizadas ";
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<NominasActualizadaCLS>();
                            NominasActualizadaCLS oNominasActualizadaCLS;
                            int posRegistro = drd.GetOrdinal("Registro");
                            int posAnio = drd.GetOrdinal("Ano");
                            int posMes = drd.GetOrdinal("Mes");
                            int posMesDescripcion = drd.GetOrdinal("MesDescripcion");
                            int posEstatus = drd.GetOrdinal("Estatus");
                            int posEstatusDescripcion = drd.GetOrdinal("EstatusDescripcion");
                            while (drd.Read())
                            {
                                oNominasActualizadaCLS = new NominasActualizadaCLS();
                                oNominasActualizadaCLS.registro = drd.GetInt32(posRegistro);
                                oNominasActualizadaCLS.anio = drd.GetInt32(posAnio);
                                oNominasActualizadaCLS.mes = drd.GetByte(posMes);
                                oNominasActualizadaCLS.mesDescripcion = drd.GetString(posMesDescripcion);
                                oNominasActualizadaCLS.estatus = drd.GetByte(posEstatus);
                                oNominasActualizadaCLS.estatusDescripcion = drd.GetString(posEstatusDescripcion);

                                lista.Add(oNominasActualizadaCLS);

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

        public int guardarNominaActualizada(NominasActualizadaCLS oNominasActualizadaCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspNominasActualizadas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Registro", oNominasActualizadaCLS.registro);
                        cmd.Parameters.AddWithValue("@Ano", oNominasActualizadaCLS.anio);
                        cmd.Parameters.AddWithValue("@Mes", oNominasActualizadaCLS.mes);
                        cmd.Parameters.AddWithValue("@Estatus", oNominasActualizadaCLS.estatus);
                        rpta = cmd.ExecuteNonQuery();
                        cn.Close();
                    }

                }
                catch (Exception ex)
                {
                    rpta = 0;
                    cn.Close();
                }
            }

            return rpta;
        }

        public NominasActualizadaCLS recuperarNominasActualizada(int registro)
        {
            var query = "SELECT * from uvwNominasActualizadas Where Registro = @Registro";
            NominasActualizadaCLS oNominasActualizadaCLS = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Registro", registro);
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            int posRegistro = drd.GetOrdinal("Registro");
                            int posAno = drd.GetOrdinal("Ano");
                            int posMes = drd.GetOrdinal("Mes");
                            int posEstatus = drd.GetOrdinal("Estatus");

                            while (drd.Read())
                            {
                                oNominasActualizadaCLS = new NominasActualizadaCLS();
                                oNominasActualizadaCLS.registro = drd.GetInt32(posRegistro);
                                oNominasActualizadaCLS.anio = drd.GetInt32(posAno);
                                oNominasActualizadaCLS.mes = drd.GetByte(posMes);
                                oNominasActualizadaCLS.estatus = drd.IsDBNull(posEstatus) ? byte.Parse("0") : drd.GetByte(posEstatus);
                            }
                        }
                    }
                    cn.Close();
                }
                catch (Exception)
                {

                    throw;
                    cn.Close();
                }
            }

            return oNominasActualizadaCLS;
        }
    }
}
