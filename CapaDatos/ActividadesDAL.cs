using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class ActividadesDAL : CadenaDAL
    {

        public int guardarActividades(ActividadesCLS oActividadesCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspActividades", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Codigo", oActividadesCLS.codigo);
                        cmd.Parameters.AddWithValue("@Descripcion", oActividadesCLS.descripcion);
                        cmd.Parameters.AddWithValue("@Estatus", oActividadesCLS.estatus);

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



        public List<ActividadesCLS> listarActividades()
        {

            List<ActividadesCLS> lista = null;

            using (SqlConnection cn = new(cadena))
            {
                var query = "SELECT * FROM uvwActividades ";
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<ActividadesCLS>();
                            ActividadesCLS oActividadesCLS;
                            int posRegistro = drd.GetOrdinal("Registro");
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posDesc = drd.GetOrdinal("Descripcion");
                            int posEstatusDescripcion = drd.GetOrdinal("EstatusDescripcion");
                            while (drd.Read())
                            {
                                oActividadesCLS = new ActividadesCLS();
                                oActividadesCLS.registro = drd.IsDBNull(posRegistro) ? 0 : drd.GetInt32(posRegistro);
                                oActividadesCLS.codigo= drd.IsDBNull(posCodigo) ? "" : drd.GetString(posCodigo);
                                oActividadesCLS.descripcion = drd.IsDBNull(posDesc) ? "" : drd.GetString(posDesc);
                                oActividadesCLS.estatusDescripcion= drd.IsDBNull(posEstatusDescripcion) ? "" : drd.GetString(posEstatusDescripcion);
                                
                                lista.Add(oActividadesCLS);

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

        public ActividadesCLS recuperarActividad(int registro)
        {
            var query = "SELECT * from uvwActividades Where Registro = @Registro";
            ActividadesCLS oActividadesCLS = null;
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
                            int posDesc = drd.GetOrdinal("Descripcion");
                            int posEstatus = drd.GetOrdinal("Estatus");

                            while (drd.Read())
                            {
                                oActividadesCLS = new ActividadesCLS();
                                oActividadesCLS.registro = drd.GetInt32(posRegistro);
                                oActividadesCLS.codigo = drd.GetString(posCodigo);
                                oActividadesCLS.descripcion = drd.GetString(posDesc);
                                oActividadesCLS.estatus = drd.IsDBNull(posEstatus) ? byte.Parse("0") : drd.GetByte(posEstatus);
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

            return oActividadesCLS;
        }

        public List<ActividadesCLS> filtrarActividad(string nombreActividad)
        {
            
            List<ActividadesCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("select Codigo, Descripcion, Estatus" +
                        " from Actividades where Estatus = 1 and Descripcion like '%" + nombreActividad + "%' ", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        if (drd != null)
                        {
                            ActividadesCLS oActividadesCLS;
                            lista = new List<ActividadesCLS>();
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posDesc = drd.GetOrdinal("Descripcion");
                            int posEstatus = drd.GetOrdinal("Estatus");
                            while (drd.Read())
                            {
                                oActividadesCLS = new ActividadesCLS();

                                oActividadesCLS.codigo = drd.GetString(posCodigo);
                                oActividadesCLS.descripcion = drd.GetString(posDesc);
                                oActividadesCLS.estatus = drd.IsDBNull(posEstatus) ? byte.Parse("0") : drd.GetByte(posEstatus);
                                lista.Add(oActividadesCLS);
                            }
                            //Cerrar conexiòn
                            cn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    lista = null;
                }



            }

            return lista;
        }

        public int eliminarActividad(int registro)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspActividadesEliminar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Registro", registro);
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
    }
}