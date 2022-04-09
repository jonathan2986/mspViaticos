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
    public class EmpleadoDAL : CadenaDAL
    {
        public List<EmpleadoCLS> listarEmpleados()
        {
            List<EmpleadoCLS> lista = null;

            using (SqlConnection cn = new(cadena))
            {
                var query = "SELECT * FROM uvwEmpleados ";
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<EmpleadoCLS>();
                            EmpleadoCLS oEmpleadoCLS;
                            int posRegistro = drd.GetOrdinal("Registro");
                            int postCodigo = drd.GetOrdinal("Codigo");
                            int postNombre = drd.GetOrdinal("Nombre");
                            int postCedula = drd.GetOrdinal("Cedula");                    
                            int posProvincia = drd.GetOrdinal("Provincia");
                            int posProvinciaNombre = drd.GetOrdinal("ProvinciaNombre");
                            int posDependencia = drd.GetOrdinal("Dependencia");
                            int posDependenciaNombre = drd.GetOrdinal("DependenciaNombre");
                            int posDepartamento = drd.GetOrdinal("Departamento");
                            int posDepartamentoNombre = drd.GetOrdinal("DepartamentoNombre");
                            int posCargo = drd.GetOrdinal("Cargo");
                            int posCargoDescripcion = drd.GetOrdinal("CargoDescripcion");
                            int posSueldo = drd.GetOrdinal("Sueldo");
                            int posEstatus = drd.GetOrdinal("Estatus");
                            int posEstatusDescripcion = drd.GetOrdinal("EstatusDescripcion");
                            while (drd.Read())
                            {
                                oEmpleadoCLS = new EmpleadoCLS();
                                oEmpleadoCLS.registro = drd.GetInt32(posRegistro);
                                oEmpleadoCLS.codigo = drd.IsDBNull(postCodigo) ? "" : drd.GetString(postCodigo);
                                oEmpleadoCLS.nombre = drd.IsDBNull(postNombre) ? "" : drd.GetString(postNombre);
                                oEmpleadoCLS.cedula = drd.IsDBNull(postCedula) ? "" : drd.GetString(postCedula);
                                oEmpleadoCLS.provincia = drd.IsDBNull(posProvincia) ? "" : drd.GetString(posProvincia);
                                oEmpleadoCLS.provinciaNombre = drd.IsDBNull(posProvinciaNombre) ? "" : drd.GetString(posProvinciaNombre);
                                oEmpleadoCLS.dependencia = drd.IsDBNull(posDependencia) ? "" : drd.GetString(posDependencia);
                                oEmpleadoCLS.dependenciaNombre = drd.IsDBNull(posDependenciaNombre) ? "" : drd.GetString(posDependenciaNombre);
                                oEmpleadoCLS.departamento = drd.IsDBNull(posDepartamento) ? "" : drd.GetString(posDepartamento);
                                oEmpleadoCLS.departamentoNombre = drd.IsDBNull(posDepartamentoNombre) ? "" : drd.GetString(posDepartamentoNombre);
                                oEmpleadoCLS.cargo = drd.IsDBNull(posCargo) ? "" : drd.GetString(posCargo);
                                oEmpleadoCLS.cargoDescripcion = drd.IsDBNull(posCargoDescripcion) ? "" : drd.GetString(posCargoDescripcion);
                                oEmpleadoCLS.sueldo = drd.IsDBNull(posProvincia) ? 0 : drd.GetDecimal(posSueldo);
                                oEmpleadoCLS.estatus = drd.GetByte(posEstatus);
                                oEmpleadoCLS.estatusDescripcion = drd.IsDBNull(posEstatusDescripcion) ? "" : drd.GetString(posEstatusDescripcion);

                                lista.Add(oEmpleadoCLS);

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

            var query = "SELECT Codigo,Nombre From uvwProvincias GO SELECT Codigo,Nombre From uvwDependencias GO  SELECT Codigo,Nombre FROM uvwDepartamentos GO  SELECT Codigo,Descripcion FROM uvwCargos";
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
                            List<ProvinciaCLS> listaProvincia = new List<ProvinciaCLS>();
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posNombre = drd.GetOrdinal("Nombre");

                            ProvinciaCLS oProvincia;
                            while (drd.Read())
                            {
                                oProvincia = new ProvinciaCLS();
                                oProvincia.codigo = drd.IsDBNull(posCodigo) ? "" : drd.GetString(posCodigo);
                                oProvincia.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);

                                listaProvincia.Add(oProvincia);
                            }
                            oComboEntidadCLS.listaProvincia = listaProvincia;


                        }
                        if (drd.NextResult())
                        {
                            List<DependenciaCLS> listaDependencia = new List<DependenciaCLS> ();
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
                        if (drd.NextResult())
                        {
                            List<DepartamentoCLS> listaDepartamento = new List<DepartamentoCLS>();
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posNombre = drd.GetOrdinal("Nombre");

                            DepartamentoCLS oDepartamentoCLS;
                            while (drd.Read())
                            {
                                oDepartamentoCLS = new DepartamentoCLS();
                                oDepartamentoCLS.codigo = drd.IsDBNull(posCodigo) ? "" : drd.GetString(posCodigo);
                                oDepartamentoCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);

                                listaDepartamento.Add(oDepartamentoCLS);
                            }
                            oComboEntidadCLS.listaDepartamento = listaDepartamento;
                        }
                        if (drd.NextResult())
                        {
                            List<CargoCLS> listaCargo = new List<CargoCLS>();
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posDescripcion = drd.GetOrdinal("Descripcion");

                            CargoCLS oCargoCLS;
                            while (drd.Read())
                            {
                                oCargoCLS = new CargoCLS();
                                oCargoCLS.codigo = drd.IsDBNull(posCodigo) ? "" : drd.GetString(posCodigo);
                                oCargoCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);

                                listaCargo.Add(oCargoCLS);
                            }
                            oComboEntidadCLS.listaCargo = listaCargo;
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

        public int guardarEmpleado(EmpleadoCLS oEmpleado)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEmpleados", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Registro", oEmpleado.registro);
                        cmd.Parameters.AddWithValue("@Codigo", oEmpleado.codigo);
                        cmd.Parameters.AddWithValue("@Nombre", oEmpleado.nombre);
                        cmd.Parameters.AddWithValue("@Cedula", oEmpleado.cedula);
                        cmd.Parameters.AddWithValue("@Provincia", oEmpleado.provincia);
                        cmd.Parameters.AddWithValue("@Dependencia", oEmpleado.dependencia);
                        cmd.Parameters.AddWithValue("@Departamento", oEmpleado.departamento);
                        cmd.Parameters.AddWithValue("@Cargo", oEmpleado.cargo);
                        cmd.Parameters.AddWithValue("@Sueldo", oEmpleado.sueldo);
                        cmd.Parameters.AddWithValue("@Estatus", oEmpleado.estatus);
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

        public EmpleadoCLS recuperarEmpleado(int registro)
        {
            var query = "SELECT * from uvwEmpleados Where Registro = @Registro";
            EmpleadoCLS oEmpleadoCLS = null;
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
                            int posCedula = drd.GetOrdinal("Cedula");
                            int posProvincia = drd.GetOrdinal("Provincia");
                            int posDependencia = drd.GetOrdinal("Dependencia");
                            int posDepartamento = drd.GetOrdinal("Departamento");
                            int posCargo = drd.GetOrdinal("Cargo");
                            int posSueldo = drd.GetOrdinal("Sueldo");
                            int posEstatus = drd.GetOrdinal("Estatus");
                            while (drd.Read())
                            {
                                oEmpleadoCLS = new EmpleadoCLS();
                                oEmpleadoCLS.registro = drd.GetInt32(posRegistro);
                                oEmpleadoCLS.codigo = drd.GetString(posCodigo);
                                oEmpleadoCLS.nombre = drd.GetString(posNombre);
                                oEmpleadoCLS.cedula = drd.GetString(posCedula);
                                oEmpleadoCLS.provincia = drd.GetString(posProvincia);
                                oEmpleadoCLS.dependencia = drd.GetString(posDependencia);
                                oEmpleadoCLS.departamento= drd.GetString(posDepartamento);
                                oEmpleadoCLS.cargo = drd.GetString(posCargo);
                                oEmpleadoCLS.sueldo = drd.GetDecimal(posSueldo);
                                oEmpleadoCLS.estatus = drd.GetByte(posEstatus);                     
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

            return oEmpleadoCLS;
        }

    }
}
