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
    public class PivoteDAL : CadenaDAL
    {
        public List<PivoteCLS> listarPivotes()
        {

            List<PivoteCLS> lista = null;

            using (SqlConnection cn = new(cadena))
            {
                var query = "SELECT * FROM uvwPivotes ";
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<PivoteCLS>();
                            PivoteCLS oPivoteCLS;
                            int posDesdeGrupoDescripcion = drd.GetOrdinal("DesdeGrupoDescripcion");
                            int posHastaGrupoDescripcion = drd.GetOrdinal("HastaGrupoDescripcion");
                            int posDesayuno = drd.GetOrdinal("Desayuno");
                            int posAlmuerzo = drd.GetOrdinal("Almuerzo");
                            int posCena = drd.GetOrdinal("Cena");
                            int posAlojamiento = drd.GetOrdinal("Alojamiento");
                            int posEstatusDescripcion = drd.GetOrdinal("EstatusDescripcion");
                            while (drd.Read())
                            {
                                oPivoteCLS = new PivoteCLS();
                                oPivoteCLS.desdeGrupoDescripcion = drd.IsDBNull(posDesdeGrupoDescripcion) ? "" : drd.GetString(posDesdeGrupoDescripcion);
                                oPivoteCLS.hastaGrupoDescripcion = drd.IsDBNull(posHastaGrupoDescripcion) ? "" : drd.GetString(posHastaGrupoDescripcion);              
                                oPivoteCLS.desayuno =  drd.GetBoolean(posDesayuno);
                                oPivoteCLS.almuerzo =  drd.GetBoolean(posAlmuerzo);
                                oPivoteCLS.cena = drd.GetBoolean(posCena);
                                oPivoteCLS.alojamiento = drd.GetBoolean(posAlojamiento);
                                oPivoteCLS.estatusDescripcion = drd.IsDBNull(posEstatusDescripcion) ? "" : drd.GetString(posEstatusDescripcion);

                                lista.Add(oPivoteCLS);

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

        public CargoComboGrupoCLS listarGrupos()
        {

            var query = "SELECT Codigo, Descripcion FROM uvwGrupos";
            CargoComboGrupoCLS oGrupoCombo = new CargoComboGrupoCLS();

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
                            List<GrupoCLS> lista = new List<GrupoCLS>();
                            //ProvinciaCLS oProvinciasCLS;
                            //int posReg = drd.GetOrdinal("Registro");
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posDescripcion = drd.GetOrdinal("Descripcion");
                            //int posRegional = drd.GetOrdinal("rn");
                            //int posDigitado = drd.GetOrdinal("Digitado");
                            GrupoCLS oGrupoCLS;
                            while (drd.Read())
                            {
                                oGrupoCLS = new GrupoCLS();
                                //oProvinciasCLS.registro = drd.GetInt32(posReg);
                                oGrupoCLS.codigo = drd.GetString(posCodigo);
                                oGrupoCLS.descripcion = drd.GetString(posDescripcion).ToUpper();
                                //oProvinciasCLS.regional = drd.GetString(posRegional).ToUpper();
                                //oProvinciasCLS.digitado = drd.GetString(posDigitado);
                                lista.Add(oGrupoCLS);

                            }
                            oGrupoCombo.listaGrupo = lista;
                        }

                    }

                    cn.Close();
                }
                catch (Exception ex)
                {

                    cn.Close();
                    oGrupoCombo = null;
                }
            }

            return oGrupoCombo;
        }

        public int guardarPivotes(PivoteCLS oPivoteCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspPivotes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Registro", oPivoteCLS.registro);
                        cmd.Parameters.AddWithValue("@DesdeGrupo", oPivoteCLS.desdeGrupo);
                        cmd.Parameters.AddWithValue("@HastaGrupo", oPivoteCLS.hastaGrupo);
                        cmd.Parameters.AddWithValue("@Desayuno", oPivoteCLS.desayuno);
                        cmd.Parameters.AddWithValue("@Almuerzo", oPivoteCLS.almuerzo);
                        cmd.Parameters.AddWithValue("@Cena", oPivoteCLS.cena);
                        cmd.Parameters.AddWithValue("@Alojamiento", oPivoteCLS.alojamiento);
                        cmd.Parameters.AddWithValue("@Estatus", oPivoteCLS.estatus);

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
    }
}
