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
    public class DependenciaDAL : CadenaDAL
    {
        public int guardarDependencia(DependenciaCLS oDependenciaCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspDependencias", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Registro", oDependenciaCLS.registro);
                        cmd.Parameters.AddWithValue("@Codigo", oDependenciaCLS.codigo);
                        cmd.Parameters.AddWithValue("@Nombre", oDependenciaCLS.nombre);
                        cmd.Parameters.AddWithValue("@DirectorAdministrativo", oDependenciaCLS.directorAdministrativo);
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
        public List<DependenciaCLS> listarDependencias()
        {
            List<DependenciaCLS> lista = null;

            using (SqlConnection cn = new(cadena))
            {
                var query = "SELECT * FROM uvwDependencias ";
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<DependenciaCLS>();
                            DependenciaCLS oDependenciaCLS;
                            int posRegistro = drd.GetOrdinal("Registro");
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posNombre = drd.GetOrdinal("Nombre");
                            int posDirectorAdministrativo = drd.GetOrdinal("DirectorAdministrativo");
                            while (drd.Read())
                            {
                                oDependenciaCLS = new DependenciaCLS();
                                oDependenciaCLS.registro = drd.GetInt32(posRegistro);
                                oDependenciaCLS.codigo = drd.IsDBNull(posCodigo) ? "" : drd.GetString(posCodigo);
                                oDependenciaCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);
                                oDependenciaCLS.directorAdministrativo = drd.IsDBNull(posDirectorAdministrativo) ? "" : drd.GetString(posDirectorAdministrativo);

                                lista.Add(oDependenciaCLS);

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

        public DependenciaCLS recuperarDependencia(int registro)
        {
            var query = "SELECT * from uvwDependencias Where Registro = @Registro";
            DependenciaCLS oDependenciaCLS = null;
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
                            int posDirectorAdministrativo = drd.GetOrdinal("DirectorAdministrativo");
                            while (drd.Read())
                            {
                                oDependenciaCLS = new DependenciaCLS();
                                oDependenciaCLS.registro = drd.GetInt32(posRegistro);
                                oDependenciaCLS.codigo = drd.GetString(posCodigo);
                                oDependenciaCLS.nombre = drd.GetString(posNombre);
                                oDependenciaCLS.directorAdministrativo = drd.IsDBNull(posDirectorAdministrativo) ? "" : drd.GetString(posDirectorAdministrativo);
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

            return oDependenciaCLS;
        }
    }
}
