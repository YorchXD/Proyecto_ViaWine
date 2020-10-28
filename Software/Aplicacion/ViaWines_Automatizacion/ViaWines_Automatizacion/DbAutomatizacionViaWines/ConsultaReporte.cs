using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ViaWines_Automatizacion.Controllers;
using ViaWines_Automatizacion.Models;

namespace ViaWines_Automatizacion.DbAutomatizacionViaWines
{
    public class ConsultaReporte
    {
        public static List<String> LeerFechasIncidentes()
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_fecha_incidencias", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<String> fechas = new List<String>();

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        DateTime fecha = Convert.ToDateTime(prodData["fecha"]);
                        String FechaFabricacion = fecha.Month + "/" + fecha.Day + "/" + fecha.Year;
                        fechas.Add(FechaFabricacion);
                    }
                    return fechas;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public static List<Area> Reporte(int Opcion, String Fecha, int Semana, int Mes, int Anio)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Reporte", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "OPTION", Direction = System.Data.ParameterDirection.Input, Value = Opcion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "DAY", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                command.Parameters.Add(new SqlParameter() { ParameterName = "WEEK", Direction = System.Data.ParameterDirection.Input, Value = Semana });
                command.Parameters.Add(new SqlParameter() { ParameterName = "MONTH", Direction = System.Data.ParameterDirection.Input, Value = Mes });
                command.Parameters.Add(new SqlParameter() { ParameterName = "YEAR", Direction = System.Data.ParameterDirection.Input, Value = Anio });
                var datos = ContexDb.GetDataSet(command);

                List<Area> areas = new List<Area>();

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        Area area = new Area()
                        {
                            Id = Convert.ToInt32(prodData["Id"]),
                            Name = prodData["nombre"].ToString(),
                            Z = Convert.ToInt32(prodData["cantIncidentes"]),
                            Y = Convert.ToInt32(prodData["cantMinutos"])
                        };

                        areas.Add(area);
                    }
                }

                List<Area> areasAux = ConsultaIncidente.LeerAreas();
                for(int i = 0; i<areasAux.Count; i++)
                {
                    Boolean validar = areas.Exists(areaAux => areaAux.Id == areasAux[i].Id);
                    if(!validar)
                    {
                        areas.Add(areasAux[i]);
                    }
                }
                areas = areas.OrderBy(area => area.Id).ToList();

                return areas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }
        /// <summary>
        /// Opcion 1 indica que solo debe traer los años que tienen incidente, por ende no es necesario mes ni año
        /// Opcion 2 indica que se debe traer los meses del año que tienen incidentes, por ende requiere que año tenga valor
        /// Opcion 3 indica que se debe obtener las semanas del mes, por ende se requiere que las variables año y mes tengan valor
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="anio"></param>
        /// <param name="mes"></param>
        /// <returns></returns>
        public static List<FiltroReporte> FiltroReporte(int opcion, int anio, int mes)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Filtro_Reporte", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "MONTH", Direction = System.Data.ParameterDirection.Input, Value = mes });
                command.Parameters.Add(new SqlParameter() { ParameterName = "YEAR", Direction = System.Data.ParameterDirection.Input, Value = anio });
                command.Parameters.Add(new SqlParameter() { ParameterName = "OPTION", Direction = System.Data.ParameterDirection.Input, Value = opcion });
                var datos = ContexDb.GetDataSet(command);
                List<FiltroReporte> filtros = new List<FiltroReporte>();

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        FiltroReporte filtro;
                        switch (opcion)
                        {
                            case 1:
                                filtro = new FiltroReporte()
                                {
                                    Anio = Convert.ToInt32(prodData["anio"])
                                };
                                break;
                            case 2:
                                filtro = new FiltroReporte()
                                {
                                    Mes = Convert.ToInt32(prodData["mes"])
                                };
                                break;
                            default:
                                filtro = new FiltroReporte()
                                {
                                    Semana = Convert.ToInt32(prodData["numSemana"]),
                                    IniSemana = Convert.ToDateTime(prodData["iniSemana"]),
                                    FinSemana = Convert.ToDateTime(prodData["finSemana"])
                                };
                                break;
                        }

                        filtros.Add(filtro);
                    }
                }
                return filtros;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static List<int> Indicadores(String Dia, int Anio, int Mes, int Semana, int TipoReporte)
        {
            List<int> indicadores = new List<int>();
            indicadores.Add(IndicadorReporte(Dia, Anio, Mes, Semana, TipoReporte, "Planificadas"));
            indicadores.Add(IndicadorReporte(Dia, Anio, Mes, Semana, TipoReporte, "No iniciadas"));
            indicadores.Add(IndicadorReporte(Dia, Anio, Mes, Semana, TipoReporte, "Pausadas"));
            indicadores.Add(IndicadorReporte(Dia, Anio, Mes, Semana, TipoReporte, "Pospuestas"));
            indicadores.Add(IndicadorReporte(Dia, Anio, Mes, Semana, TipoReporte, "Finalizadas"));
            return indicadores;
        }

        public static int IndicadorReporte(String Dia, int Anio, int Mes, int Semana, int TipoReporte, String TipoInicador)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "IndicadoresReporte", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "DAY", Direction = System.Data.ParameterDirection.Input, Value = Dia });
                command.Parameters.Add(new SqlParameter() { ParameterName = "YEAR", Direction = System.Data.ParameterDirection.Input, Value = Anio });
                command.Parameters.Add(new SqlParameter() { ParameterName = "MONTH", Direction = System.Data.ParameterDirection.Input, Value = Mes });
                command.Parameters.Add(new SqlParameter() { ParameterName = "WEEK", Direction = System.Data.ParameterDirection.Input, Value = Semana });
                command.Parameters.Add(new SqlParameter() { ParameterName = "OPTION", Direction = System.Data.ParameterDirection.Input, Value = TipoReporte });
                command.Parameters.Add(new SqlParameter() { ParameterName = "tipoIndicador", Direction = System.Data.ParameterDirection.Input, Value = TipoInicador });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    var prodData = datos.Tables[0].Rows[0];
                    return Convert.ToInt32(prodData["cantOrden"]);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }
    }
}
