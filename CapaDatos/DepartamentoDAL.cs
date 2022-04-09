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
    public class DepartamentoDAL : CadenaDAL
    {
        public int guardarDepartamentos(DepartamentoCLS oDepartamentoCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspDepartamentos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Registro", oDepartamentoCLS.registro);
                        cmd.Parameters.AddWithValue("@Codigo", oDepartamentoCLS.codigo);
                        cmd.Parameters.AddWithValue("@Nombre", oDepartamentoCLS.nombre);
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

        public List<DepartamentoCLS> listarDepartamento()
        {
            List<DepartamentoCLS> lista = null;

            using (SqlConnection cn = new(cadena))
            {
                var query = "SELECT * FROM uvwDepartamentos ";
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<DepartamentoCLS>();
                            DepartamentoCLS oDepartamentoCLS;
                            int posRegistro = drd.GetOrdinal("Registro");
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posNombre = drd.GetOrdinal("Nombre");
                            while (drd.Read())
                            {
                                oDepartamentoCLS = new DepartamentoCLS();
                                oDepartamentoCLS.registro = drd.GetInt32(posRegistro);
                                oDepartamentoCLS.codigo = drd.IsDBNull(posCodigo) ? "" : drd.GetString(posCodigo);
                                oDepartamentoCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);
                              

                                lista.Add(oDepartamentoCLS);

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

        public DepartamentoCLS recuperarDepartamento(int registro)
        {
            var query = "SELECT * from uvwDepartamentos Where Registro = @Registro";
            DepartamentoCLS oDepartamentoCLS = null;
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
                            int posNombre = drd.GetOrdinal("Nombre");

                            while (drd.Read())
                            {
                                oDepartamentoCLS = new DepartamentoCLS();
                                oDepartamentoCLS.registro = drd.GetInt32(posRegistro);
                                oDepartamentoCLS.codigo = drd.GetString(posCodigo);
                                oDepartamentoCLS.nombre = drd.GetString(posNombre);        
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

            return oDepartamentoCLS;
        }
    }
}
