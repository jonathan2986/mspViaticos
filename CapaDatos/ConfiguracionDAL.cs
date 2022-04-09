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
    public class ConfiguracionDAL: CadenaDAL
    {
        public List<ConfiguracionCLS> listarConfiguracion()
        {
            List<ConfiguracionCLS> lista = null;

            using (SqlConnection cn = new(cadena))
            {
                var query = "SELECT * FROM uvwConfiguracion ";
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new(query, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<ConfiguracionCLS>();
                            ConfiguracionCLS oConfiguracionCLS;
                            int posDesdePagoDiaSueldo = drd.GetOrdinal("DesdePagoDiaSueldo");
                            int posDesdePagoDiaSueldoAMPM = drd.GetOrdinal("DesdePagoDiaSueldoAMPM");
                            int posHastaPagoDiaSueldo = drd.GetOrdinal("HastaPagoDiaSueldo");
                            int posHastaPagoDiaSueldoAMPM = drd.GetOrdinal("HastaPagoDiaSueldoAMPM");
                            int posFactorDiasLaboralesMes = drd.GetOrdinal("FactorDiasLaboralesMes");
                            int posDesdeDesayuno = drd.GetOrdinal("DesdeDesayuno");
                            int posDesdeDesayunoAMPM = drd.GetOrdinal("DesdeDesayunoAMPM");
                            int posHastaDesayuno = drd.GetOrdinal("HastaDesayuno");
                            int posHastaDesayunoAMPM = drd.GetOrdinal("HastaDesayunoAMPM");
                            int posPorcientoDesayuno = drd.GetOrdinal("PorcientoDesayuno");
                            int posDesdeAlmuerzo = drd.GetOrdinal("DesdeAlmuerzo");
                            int posDesdeAlmuerzoAMPM = drd.GetOrdinal("DesdeAlmuerzoAMPM");
                            int posHastaAlmuerzo = drd.GetOrdinal("HastaAlmuerzo");
                            int posHastaAlmuerzoAMPM = drd.GetOrdinal("HastaAlmuerzoAMPM");
                            int posPorcientoAlmuerzo = drd.GetOrdinal("PorcientoAlmuerzo");
                            int posDesdeCena = drd.GetOrdinal("DesdeCena");
                            int posDesdeCenaAMPM = drd.GetOrdinal("DesdeCenaAMPM");
                            int posHastaCena = drd.GetOrdinal("HastaCena");
                            int posHastaCenaAMPM = drd.GetOrdinal("HastaCenaAMPM");
                            int posPorcientoCena = drd.GetOrdinal("PorcientoCena");
                            int posPorcientoAlojamiento = drd.GetOrdinal("PorcientoAlojamiento");
                            while (drd.Read())
                            {
                                oConfiguracionCLS = new ConfiguracionCLS();
                                oConfiguracionCLS.desdePagoDiaSueldo = drd.IsDBNull(posDesdePagoDiaSueldo) ? "" : drd.GetString(posDesdePagoDiaSueldo);
                                oConfiguracionCLS.desdePagoDiaSueldoAMPM = drd.IsDBNull(posDesdePagoDiaSueldoAMPM) ? "" : drd.GetString(posDesdePagoDiaSueldoAMPM);
                                oConfiguracionCLS.hastaPagoDiaSueldo = drd.IsDBNull(posHastaPagoDiaSueldo) ? "" : drd.GetString(posHastaPagoDiaSueldo);
                                oConfiguracionCLS.hastaPagoDiaSueldoAMPM = drd.IsDBNull(posHastaPagoDiaSueldoAMPM) ? "" : drd.GetString(posHastaPagoDiaSueldoAMPM);
                                oConfiguracionCLS.factorDiasLaboralesMes = drd.IsDBNull(posFactorDiasLaboralesMes) ? 0 : drd.GetDecimal(posFactorDiasLaboralesMes);
                                oConfiguracionCLS.desdeDesayuno = drd.IsDBNull(posDesdeDesayuno) ? "" : drd.GetString(posDesdeDesayuno);
                                oConfiguracionCLS.desdeDesayunoAMPM = drd.IsDBNull(posDesdeDesayunoAMPM) ? "" : drd.GetString(posDesdeDesayunoAMPM);
                                oConfiguracionCLS.hastaDesayuno = drd.IsDBNull(posHastaDesayuno) ? "" : drd.GetString(posHastaDesayuno);
                                oConfiguracionCLS.hastaDesayunoAMPM = drd.IsDBNull(posHastaDesayunoAMPM) ? "" : drd.GetString(posHastaDesayunoAMPM);
                                oConfiguracionCLS.porcientoDesayuno = drd.IsDBNull(posPorcientoDesayuno) ? 0 : drd.GetDecimal(posPorcientoDesayuno);
                                oConfiguracionCLS.desdeAlmuerzo = drd.IsDBNull(posDesdeAlmuerzo) ? "" : drd.GetString(posDesdeAlmuerzo);
                                oConfiguracionCLS.desdeAlmuerzoAMPM = drd.IsDBNull(posDesdeAlmuerzoAMPM) ? "" : drd.GetString(posDesdeAlmuerzoAMPM);
                                oConfiguracionCLS.hastaAlmuerzo = drd.IsDBNull(posHastaAlmuerzo) ? "" : drd.GetString(posHastaAlmuerzo);
                                oConfiguracionCLS.hastaAlmuerzoAMPM = drd.IsDBNull(posHastaAlmuerzoAMPM) ? "" : drd.GetString(posHastaAlmuerzoAMPM);
                                oConfiguracionCLS.porcientoAlmuerzo = drd.IsDBNull(posPorcientoAlmuerzo) ? 0 : drd.GetDecimal(posPorcientoAlmuerzo);
                                oConfiguracionCLS.desdeCena = drd.IsDBNull(posDesdeCena) ? "" : drd.GetString(posDesdeCenaAMPM);
                                oConfiguracionCLS.desdeCenaAMPM = drd.IsDBNull(posDesdeCenaAMPM) ? "" : drd.GetString(posDesdeAlmuerzoAMPM);
                                oConfiguracionCLS.hastaCena = drd.IsDBNull(posHastaCena) ? "" : drd.GetString(posHastaCena);
                                oConfiguracionCLS.hastaCenaAMPM = drd.IsDBNull(posHastaCenaAMPM) ? "" : drd.GetString(posHastaCenaAMPM);
                                oConfiguracionCLS.porcientoCena = drd.IsDBNull(posPorcientoCena) ? 0 : drd.GetDecimal(posPorcientoCena);
                                oConfiguracionCLS.porcientoAlojamiento = drd.IsDBNull(posPorcientoAlojamiento) ? 0 : drd.GetDecimal(posPorcientoAlojamiento);
            

                                lista.Add(oConfiguracionCLS);

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
    }
}
