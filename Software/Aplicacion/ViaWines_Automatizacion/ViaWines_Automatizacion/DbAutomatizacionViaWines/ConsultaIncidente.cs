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
    public class ConsultaIncidente
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

        public static List<IncidenteOPI> LeerOPIDia(String Fecha)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_OPI_por_fecha", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                var datos = ContexDb.GetDataSet(command);
                List<IncidenteOPI> Incidentes = new List<IncidenteOPI>();

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        IncidenteOPI incidente = new IncidenteOPI()
                        {
                            CodigoCorto = Convert.ToInt32(prodData["CodigoCorto"]),
                            CodigoLargo = prodData["CodigoLargo"].ToString(),
                            Tiempo = prodData["Tiempo"].ToString(),
                            Clasificacion = prodData["Clasificacion"].ToString(),
                            Aclaracion = prodData["Aclaracion"].ToString(),
                            Zona = prodData["Zona"].ToString(),
                            CantIncidentes = Convert.ToInt32(prodData["CantIncidente"])
                        };
                        Incidentes.Add(incidente);
                    }
                    return Incidentes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }


        public static int FinalizarIncidentePorId(int idIncidente, DateTime FechaHoraTermino)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Finalizar_Incidencia_Por_Id", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdIncidente", Direction = System.Data.ParameterDirection.Input, Value = idIncidente });
                command.Parameters.Add(new SqlParameter() { ParameterName = "FechaHoraTermino", Direction = System.Data.ParameterDirection.Input, Value = FechaHoraTermino });
                ContexDb.ExecuteProcedure(command);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return -1;
        }

        public static int RegistrarIncidencia(int IdIncidente, DateTime FechaHoraInicio, string Observacion)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "InsertarIncidenteSinOrden", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdIncidente", Direction = System.Data.ParameterDirection.Input, Value = IdIncidente });
                command.Parameters.Add(new SqlParameter() { ParameterName = "FechaHoraInicio", Direction = System.Data.ParameterDirection.Input, Value = FechaHoraInicio });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Observacion", Direction = System.Data.ParameterDirection.Input, Value = Observacion });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    var prodData = datos.Tables[0].Rows[0];
                    return Convert.ToInt32(prodData["id"]);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }

        public static int ActualizarObservacionIncidente(int idIncidente, String Observacion)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Actualizar_Observacion_Incidente", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdIncidente", Direction = System.Data.ParameterDirection.Input, Value = idIncidente });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Observacion", Direction = System.Data.ParameterDirection.Input, Value = Observacion });
                ContexDb.ExecuteProcedure(command);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return -1;
        }

        public static Incidente LeerIncidencia(int IdIncidente)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Incidentes", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<Incidente> incidencias = new List<Incidente>();

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        Incidente incidetente = new Incidente()
                        {
                            IdIncidente = Convert.ToInt32(prodData["idIncidente"]),
                            IdAgrupacionTiempo = prodData["idAgrupacion"].ToString(),
                            NombreAgrupacionTiempo = prodData["nombreAgrupacion"].ToString(),
                            IdClasificacion = prodData["idClasificacion"].ToString(),
                            DescripcionClasificacion = prodData["descripcionClasificacion"].ToString(),
                            AclaracionClasificacion = prodData["aclaracionClasificacion"].ToString(),
                            ReqObservacion = prodData["reqObservacionClasificacion"].ToString(),
                            IdZona = prodData["idZona"].ToString(),
                            NombreZona = prodData["nombreZona"].ToString()
                        };
                        incidencias.Add(incidetente);
                    }
                    return incidencias.Find(incidente => incidente.IdIncidente == IdIncidente);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public static List<Incidente> LeerIncidencias()
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Incidentes", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<Incidente> incidencias = new List<Incidente>();

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        Incidente incidetente = new Incidente()
                        {
                            IdIncidente = Convert.ToInt32(prodData["idIncidente"]),
                            IdAgrupacionTiempo = prodData["idAgrupacion"].ToString(),
                            NombreAgrupacionTiempo = prodData["nombreAgrupacion"].ToString(),
                            IdClasificacion = prodData["idClasificacion"].ToString(),
                            DescripcionClasificacion = prodData["descripcionClasificacion"].ToString(),
                            AclaracionClasificacion = prodData["aclaracionClasificacion"].ToString(),
                            ReqObservacion = prodData["reqObservacionClasificacion"].ToString(),
                            IdZona = prodData["idZona"].ToString(),
                            NombreZona = prodData["nombreZona"].ToString()
                        };
                        incidencias.Add(incidetente);
                    }
                    return incidencias;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public static List<RegistroIncidente> LeerRegistroIncidente(String Fecha, int RefIncidente)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_registros_incidentes", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdIncidente", Direction = System.Data.ParameterDirection.Input, Value = RefIncidente });
                var datos = ContexDb.GetDataSet(command);
                List<RegistroIncidente> RegitroIncidentes = new List<RegistroIncidente>();

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        RegistroIncidente regsitro = new RegistroIncidente()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            RefOrden = Convert.ToInt32(prodData["refOrden"]),
                            FechaHoraInicio = Convert.ToDateTime(prodData["fechaHoraInicio"]),
                            FechaHoraTermino = Convert.ToDateTime(prodData["fechaHoraTermino"]),
                            CantMinutos = Convert.ToInt32(prodData["cantMinutos"]),
                            EstadoOrden = prodData["estadoOrden"].ToString(),
                            ProgresoOrden = Convert.ToDouble(prodData["progresoOrden"]),
                            Observacion = prodData["observacion"].ToString()

                        };
                        RegitroIncidentes.Add(regsitro);
                    }
                    return RegitroIncidentes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }
    }
}


