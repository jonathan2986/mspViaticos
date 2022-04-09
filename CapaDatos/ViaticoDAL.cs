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
    public class ViaticoDAL : CadenaDAL
    {
        public List<ViaticoCLS> listarViaticos()
        {
            var query = "SELECT * from uvwViaticos";
            List<ViaticoCLS> lista = null;
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {

                try
                {
                    cn.Open();
                    //llamar el procedure
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<ViaticoCLS>();
                            ViaticoCLS oViaticoCLS;
                            int posReg = drd.GetOrdinal("Registro");
                            int posProvincia = drd.GetOrdinal("Provincia");
                            int posProvinciaNombre = drd.GetOrdinal("ProvinciaNombre");
                            int posDependencia = drd.GetOrdinal("Dependencia");
                            int posDependenciaNombre = drd.GetOrdinal("DependenciaNombre");
                            int posNumero = drd.GetOrdinal("Numero");
                            int posFecha = drd.GetOrdinal("Fecha");
                            int posEmpleado = drd.GetOrdinal("Empleado");
                            int posEmpleadoNombreFull = drd.GetOrdinal("NombreFull");
                            int posDepartamento = drd.GetOrdinal("Departamento");
                            int posDepartamentoNombre = drd.GetOrdinal("DepartamentoNombre");
                            int posCargo = drd.GetOrdinal("Cargo");
                            int posCargoDescripcion = drd.GetOrdinal("CargoDescripcion");
                            int posSueldo = drd.GetOrdinal("Sueldo");
                            int posMetodo = drd.GetOrdinal("Metodo");
                            int posMetodoDescripcion = drd.GetOrdinal("MetodoDesc");
                            int posGrupo = drd.GetOrdinal("Grupo");
                            int posGrupoDescripcion = drd.GetOrdinal("GrupoDescripcion");
                            int posTarifa = drd.GetOrdinal("Tarifa");
                            int posComentario = drd.GetOrdinal("Comentario");
                            int posFechaSalida = drd.GetOrdinal("FechaSalida");
                            int posHoraSalida = drd.GetOrdinal("HoraSalida");
                            int posFechaRetorno = drd.GetOrdinal("FechaRetorno");
                            int posHoraRetorno = drd.GetOrdinal("HoraRetorno");
                            int posProvinciaEnviado = drd.GetOrdinal("ProvinciaEnviado");
                            int posProvinciaEnviadoNombre = drd.GetOrdinal("ProvinciaEnviadoNombre");
                            int posActividad = drd.GetOrdinal("Actividad");
                            int posActividadDescripcion = drd.GetOrdinal("ActividadDescripcion");
                            int posDesayuno = drd.GetOrdinal("Desayuno");
                            int posAlmuerzo = drd.GetOrdinal("Almuerzo");
                            int posCena = drd.GetOrdinal("Cena");
                            int posAlojamiento = drd.GetOrdinal("Alojamiento");
                            int posTotalDieta = drd.GetOrdinal("TotalDieta");
                            int posTransporte = drd.GetOrdinal("Transporte");
                            int posTotalViaje = drd.GetOrdinal("TotalViaje");
                            int posEstatus = drd.GetOrdinal("Estatus");
                            int posEstatusDescripcion = drd.GetOrdinal("EstatusDescripcion");
 



                            while (drd.Read())
                            {
                                oViaticoCLS = new ViaticoCLS();
                                oViaticoCLS.registro = drd.GetInt32(posReg);
                                oViaticoCLS.provinciaCodigo = drd.GetString(posProvincia);
                                oViaticoCLS.provinciaNombre = drd.GetString(posProvinciaNombre).ToUpper();
                                oViaticoCLS.dependenciaCodigo = drd.GetString(posDependencia).ToUpper();
                                oViaticoCLS.dependenciaNombre = drd.GetString(posDependenciaNombre).ToUpper();
                                oViaticoCLS.numero = drd.GetInt32(posNumero);
                                oViaticoCLS.fecha = drd.GetDateTime(posFecha);
                                oViaticoCLS.empleadoCodigo = drd.GetString(posEmpleado);
                                oViaticoCLS.nombreEmpleado = drd.GetString(posEmpleadoNombreFull);
                                oViaticoCLS.departamento = drd.GetString(posDepartamento);
                                oViaticoCLS.departamentoNombre = drd.GetString(posDepartamentoNombre);
                                oViaticoCLS.cargoCodigo= drd.GetString(posCargoDescripcion).ToUpper();
                                oViaticoCLS.cargoDescripcion = drd.GetString(posCargoDescripcion);
                                oViaticoCLS.sueldo = drd.GetDecimal(posSueldo);
                                oViaticoCLS.metodo = drd.GetByte(posMetodo);
                                oViaticoCLS.metodoDescripcion = drd.GetString(posMetodoDescripcion);
                                oViaticoCLS.grupoCodigo = drd.GetString(posGrupo);
                                oViaticoCLS.grupoDescripcion = drd.GetString(posGrupoDescripcion);
                                oViaticoCLS.tarifa = drd.GetDecimal(posTarifa);                              
                                oViaticoCLS.comentario = drd.GetString(posComentario);
                                oViaticoCLS.fechaSalida = drd.GetDateTime(posFechaSalida);
                                oViaticoCLS.horaSalida = drd.GetString(posHoraSalida);
                                oViaticoCLS.fechaRetorno = drd.GetDateTime(posFechaRetorno);
                                oViaticoCLS.horaRetorno = drd.GetString(posHoraRetorno);
                                oViaticoCLS.provinciaEnviado = drd.GetString(posProvinciaEnviado);
                                oViaticoCLS.provinciaEnviadoNombre = drd.GetString(posProvinciaEnviadoNombre);
                                oViaticoCLS.actividadCodigo = drd.GetString(posActividad);
                                oViaticoCLS.actividadDescripcion = drd.GetString(posActividadDescripcion);
                                oViaticoCLS.desayuno = drd.GetDecimal(posDesayuno);
                                oViaticoCLS.almuerzo = drd.GetDecimal(posAlmuerzo);
                                oViaticoCLS.cena = drd.GetDecimal(posCena);
                                oViaticoCLS.alojamiento = drd.GetDecimal(posAlojamiento);
                                oViaticoCLS.totalDieta = drd.GetDecimal(posTotalDieta);
                                oViaticoCLS.transporte = drd.GetDecimal(posTransporte);
                                oViaticoCLS.totalViaje = drd.GetDecimal(posTotalViaje);
                                oViaticoCLS.estatus = drd.GetByte(posEstatus);
                                oViaticoCLS.estatusDescripcion = drd.GetString(posEstatusDescripcion);
                               



                                lista.Add(oViaticoCLS);

                            }
                        }

                    }

                    cn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                    cn.Close();
                }
            }

            return lista;
        }

        public ViaticoComboCLS listarCombosViatico()
        {
            ViaticoComboCLS oViaticoComboCLS = new ViaticoComboCLS();
            string query = "select Codigo, Nombre from Provincias" + "\nselect Codigo, Nombre from Dependencias" + "\nselect Codigo, Nombre from DistritosMunicipales" + "\nselect Codigo, Nombre from Empleados";
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cn))
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
                            oViaticoComboCLS.listaProvincia = listaProvincia;


                        }
                        if (drd.NextResult())
                        {
                            List<DependenciaCLS> listaDependencia = new List<DependenciaCLS>();
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posNombre = drd.GetOrdinal("Nombre");

                            DependenciaCLS oDependencia;
                            while (drd.Read())
                            {
                                oDependencia = new DependenciaCLS();
                                oDependencia.codigo = drd.IsDBNull(posCodigo) ? "" : drd.GetString(posCodigo);
                                oDependencia.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);

                                listaDependencia.Add(oDependencia);
                            }
                            oViaticoComboCLS.listaDependencia = listaDependencia;
                        }
 
                        if (drd.NextResult())
                        {
                            List<EmpleadoCLS> listaEmpleado = new List<EmpleadoCLS>();
                            int posCodigo = drd.GetOrdinal("Codigo");
                            int posNombre = drd.GetOrdinal("Nombre");

                            EmpleadoCLS oEmpleado;
                            while (drd.Read())
                            {
                                oEmpleado = new EmpleadoCLS();
                                oEmpleado.codigo = drd.IsDBNull(posCodigo) ? "" : drd.GetString(posCodigo);
                                oEmpleado.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);

                                listaEmpleado.Add(oEmpleado);
                            }
                            oViaticoComboCLS.listaEmpleado = listaEmpleado;
                        }

                     
                        cn.Close();
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                    cn.Close();
                    //null para mi es error
                    oViaticoComboCLS = null;
                }

            }

            return oViaticoComboCLS;
        }
    }
}
