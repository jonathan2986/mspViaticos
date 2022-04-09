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
    public class CargoDAL : CadenaDAL
    {
        public List<CargoCLS> listarCargos()
        {
            List<CargoCLS> lista = null;

            using (SqlConnection cn = new(cadena))
            {
                var query = "SELECT * FROM uvwCargos ";
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<CargoCLS>();
                            CargoCLS oCargoCLS;
                            int posRegistro = drd.GetOrdinal("Registro");
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posDescripcion = drd.GetOrdinal("Descripcion");
                            int posGrupoDescripcion = drd.GetOrdinal("GrupoDescripcion");
                            while (drd.Read())
                            {
                                oCargoCLS = new CargoCLS();
                                oCargoCLS.registro = drd.GetInt32(posRegistro);
                                oCargoCLS.codigo = drd.IsDBNull(posCodigo) ? "" : drd.GetString(posCodigo);
                                oCargoCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                                oCargoCLS.grupoDescripcion = drd.IsDBNull(posGrupoDescripcion) ? "" : drd.GetString(posGrupoDescripcion);

                                lista.Add(oCargoCLS);

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

        public int guardarCargo(CargoCLS oCargoCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspCargos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Registro", oCargoCLS.registro);
                        cmd.Parameters.AddWithValue("@Codigo", oCargoCLS.codigo);
                        cmd.Parameters.AddWithValue("@Descripcion", oCargoCLS.descripcion);
                        cmd.Parameters.AddWithValue("@Grupo", oCargoCLS.grupo);
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

        public CargoCLS recuperarCargoo(int registro)
        {
            var query = "SELECT * from uvwCargos Where Registro = @Registro";
            CargoCLS oCargoCLS = null;
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
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posDescripcion = drd.GetOrdinal("Descripcion");
                            int postGrupo = drd.GetOrdinal("Grupo");

                            while (drd.Read())
                            {
                                oCargoCLS = new CargoCLS();
                                oCargoCLS.registro = drd.GetInt32(posRegistro);
                                oCargoCLS.codigo = drd.GetString(posCodigo);
                                oCargoCLS.descripcion = drd.GetString(posDescripcion);
                                oCargoCLS.grupo = drd.IsDBNull(postGrupo) ? "" : drd.GetString(postGrupo);
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

            return oCargoCLS;
        }

    }
}
