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
    public class PeriodoDAL : CadenaDAL
    {
        public List<PeriodoCLS> listaPeriodo()
        {
            List<PeriodoCLS> lista = null;

            using (SqlConnection cn = new(cadena))
            {
                var query = "SELECT * FROM uvwPeriodos ";
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<PeriodoCLS>();
                            PeriodoCLS oPeriodoCLS;
                            int posDependencia= drd.GetOrdinal("Dependencia");
                            int posNombreDependencia = drd.GetOrdinal("Nombre");                           
                            int posAnio = drd.GetOrdinal("Ano");
                            int posMes = drd.GetOrdinal("Mes");
                            int posMesDescripcion = drd.GetOrdinal("Descripcion");
                            int posDesde= drd.GetOrdinal("Desde");
                            int posHasta= drd.GetOrdinal("Hasta");
                            int posEstatus = drd.GetOrdinal("Estatus");
                            int posEstatusDescripcion = drd.GetOrdinal("EstatusDescripcion");
                            while (drd.Read())
                            {
                                oPeriodoCLS = new PeriodoCLS();
                                oPeriodoCLS.dependencia = drd.GetString(posDependencia);
                                oPeriodoCLS.nombreDependencia = drd.GetString(posNombreDependencia);
                                oPeriodoCLS.anio = drd.GetInt32(posAnio);
                                oPeriodoCLS.mes = drd.GetByte(posMes);
                                oPeriodoCLS.mesDescripcion = drd.IsDBNull(posMesDescripcion) ? "" : drd.GetString(posMesDescripcion);
                                oPeriodoCLS.desde = drd.GetDateTime(posDesde);
                                oPeriodoCLS.hasta = drd.GetDateTime(posHasta);
                                oPeriodoCLS.estatus = drd.GetByte(posEstatus);

                                oPeriodoCLS.estatusDescripcion = drd.GetString(posEstatusDescripcion);

                                lista.Add(oPeriodoCLS);

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

        public ComboEntidadCLS listarCombos()
        {

            var query = "SELECT Codigo,Nombre From uvwDependencias ";
            ComboEntidadCLS oComboEntidadCLS = new ComboEntidadCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        //Le indico que es un procedure
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader drd = cmd.ExecuteReader();
                        
                        if (drd != null)
                        {
                            List<DependenciaCLS> listaDependencia = new List<DependenciaCLS>();
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posNombre = drd.GetOrdinal("Nombre");

                            DependenciaCLS oDependenciaCLS;
                            while (drd.Read())
                            {
                                oDependenciaCLS = new DependenciaCLS();
                                oDependenciaCLS.codigo = drd.IsDBNull(posCodigo) ? "" : drd.GetString(posCodigo);
                                oDependenciaCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);

                                listaDependencia.Add(oDependenciaCLS);
                            }
                            oComboEntidadCLS.listaDependencia = listaDependencia;
                        }
                       
                      
                        cn.Close();
                    }

                }
                catch (Exception ex)
                {
                    cn.Close();
                    //null para mi es error
                    oComboEntidadCLS = null;
                }

            }

            return oComboEntidadCLS;
        }

        public int guardarPeriodo(PeriodoCLS oPeriodoCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspPeriodos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Registro", oPeriodoCLS.registro);
                        cmd.Parameters.AddWithValue("@Dependencia", oPeriodoCLS.dependencia);
                        cmd.Parameters.AddWithValue("@Ano", oPeriodoCLS.anio);
                        cmd.Parameters.AddWithValue("@Mes", oPeriodoCLS.mes);
                        cmd.Parameters.AddWithValue("@Desde", oPeriodoCLS.desde);
                        cmd.Parameters.AddWithValue("@Hasta", oPeriodoCLS.hasta);
                        cmd.Parameters.AddWithValue("@Estatus", oPeriodoCLS.estatus);

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
