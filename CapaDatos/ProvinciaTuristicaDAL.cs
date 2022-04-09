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
    public class ProvinciaTuristicaDAL : CadenaDAL
    {
        public List<ProvinciaTuristicaCLS> listarProvinciaTuristica()
        {
            List<ProvinciaTuristicaCLS> lista = null;

            using (SqlConnection cn = new(cadena))
            {
                var query = "SELECT * FROM uvwProvinciasTuristicas ";
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<ProvinciaTuristicaCLS>();
                            ProvinciaTuristicaCLS oProvinciaTuristicaCLS;
                            int posRegistro = drd.GetOrdinal("Registro");
                            int posProvincia = drd.GetOrdinal("Provincia");
                            int posNombreProvincia = drd.GetOrdinal("Nombre");
                            int posPorciento = drd.GetOrdinal("Porciento");
                            while (drd.Read())
                            {
                                oProvinciaTuristicaCLS = new ProvinciaTuristicaCLS();
                                oProvinciaTuristicaCLS.registro = drd.GetInt32(posRegistro);
                                oProvinciaTuristicaCLS.provincia = drd.IsDBNull(posProvincia) ? "" : drd.GetString(posProvincia);
                                oProvinciaTuristicaCLS.nombreProvincia = drd.IsDBNull(posNombreProvincia) ? "" : drd.GetString(posNombreProvincia);
                                oProvinciaTuristicaCLS.porciento = drd.IsDBNull(posPorciento) ? 0 : drd.GetDecimal(posPorciento);

                                lista.Add(oProvinciaTuristicaCLS);

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

        public ComboProvinciaCLS listarProvincias()
        {

            var query = "SELECT Codigo, Nombre FROM uvwProvincias";
            ComboProvinciaCLS oComboProvinciaCLS = new ComboProvinciaCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    //llamar el procedure
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                        if (drd != null)
                        {
                            List<ProvinciaCLS> lista = new List<ProvinciaCLS>();
                            //ProvinciaCLS oProvinciasCLS;
                            //int posReg = drd.GetOrdinal("Registro");
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posNombre = drd.GetOrdinal("Nombre");
                            //int posRegional = drd.GetOrdinal("rn");
                            //int posDigitado = drd.GetOrdinal("Digitado");
                            ProvinciaCLS oProvinciaCLS;
                            while (drd.Read())
                            {
                                oProvinciaCLS = new ProvinciaCLS();
                                //oProvinciasCLS.registro = drd.GetInt32(posReg);
                                oProvinciaCLS.codigo = drd.GetString(posCodigo);
                                oProvinciaCLS.nombre = drd.GetString(posNombre).ToUpper();
                                //oProvinciasCLS.regional = drd.GetString(posRegional).ToUpper();
                                //oProvinciasCLS.digitado = drd.GetString(posDigitado);
                                lista.Add(oProvinciaCLS);

                            }
                            oComboProvinciaCLS.listaProvincia = lista;
                        }

                    }

                    cn.Close();
                }
                catch (Exception ex)
                {

                    cn.Close();
                    oComboProvinciaCLS = null;
                }
            }

            return oComboProvinciaCLS;
        }

        public int guardarProvinciaTuristica(ProvinciaTuristicaCLS oProvinciaTuristicaCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspProvinciasTuristicas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Registro", oProvinciaTuristicaCLS.registro);
                        cmd.Parameters.AddWithValue("@Provincia", oProvinciaTuristicaCLS.provincia);
                        cmd.Parameters.AddWithValue("@Porciento", oProvinciaTuristicaCLS.porciento);  
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

        public ProvinciaTuristicaCLS recuperarProvinciaTuristica(int registro)
        {
            var query = "SELECT * from uvwProvinciasTuristicas Where Registro = @Registro";
            ProvinciaTuristicaCLS oProvinciaTuristicaCLS = null;
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
                            int posProvincia = drd.GetOrdinal("Provincia");
                            int posPorciento = drd.GetOrdinal("Porciento");

                            while (drd.Read())
                            {
                                oProvinciaTuristicaCLS = new ProvinciaTuristicaCLS();
                                oProvinciaTuristicaCLS.registro = drd.GetInt32(posRegistro);
                                oProvinciaTuristicaCLS.provincia = drd.GetString(posProvincia);
                                oProvinciaTuristicaCLS.porciento = drd.GetDecimal(posPorciento);
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

            return oProvinciaTuristicaCLS;
        }

    }
}
