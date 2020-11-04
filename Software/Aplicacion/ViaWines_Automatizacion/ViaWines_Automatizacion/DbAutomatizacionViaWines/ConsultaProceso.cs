using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ViaWines_Automatizacion.Models;

namespace ViaWines_Automatizacion.DbAutomatizacionViaWines
{
    public class ConsultaProceso
    {
        public static int ActualizarEstadoOrden(int Id, int Estado, String Fecha)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Actualizar_Estado_Orden", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "Id", Direction = System.Data.ParameterDirection.Input, Value = Id });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Estado", Direction = System.Data.ParameterDirection.Input, Value = Estado });
                //command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                ContexDb.ExecuteProcedure(command);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }

        public static List<String> GetFechasOrdenesPlanificadas()
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Fechas_Planificadas1", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<String> fechas = new List<String>();

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        DateTime fecha = Convert.ToDateTime(prodData["fechaFabricacion"]);
                        //String date = DateTime.ParseExact(prodData["fechaFabricacion"].ToString(), "MM/dd/yyyy", CultureInfo.InstalledUICulture).ToString("MM/dd/yyyy"); 
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

        public static List<String> LeerFechasOrdenesAbiertas()
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Fechas_Ordenes_Abiertas", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<String> fechas = new List<String>();

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        DateTime fecha = Convert.ToDateTime(prodData["fechaFabricacion"]);
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

        /*
         * de momento no se utilizará esta funcion
        public static void InsertarLogEstadoOrden(int OrdenFabricacion, int Estado)
        {
            string fecha = DateTime.Today.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("HH:mm:ss");
            string evento = "";

            switch (Estado)
            {
                case 1:
                    evento = "Se ha iniciado la orden numero " + OrdenFabricacion;
                    break;
                case 2:
                    evento = "Se ha pausado la orden numero " + OrdenFabricacion;
                    break;
                case 3:
                    evento = "Se ha pospuesto la orden numero " + OrdenFabricacion;
                    break;
                case 4:
                    evento = "Se ha finalizado la orden numero " + OrdenFabricacion;
                    break;
            }

            var command = new SqlCommand() { CommandText = "InsertarLog", CommandType = System.Data.CommandType.StoredProcedure };
            command.Parameters.Add(new SqlParameter() { ParameterName = "fecha", Direction = System.Data.ParameterDirection.Input, Value = fecha });
            command.Parameters.Add(new SqlParameter() { ParameterName = "hora", Direction = System.Data.ParameterDirection.Input, Value = hora });
            command.Parameters.Add(new SqlParameter() { ParameterName = "evento", Direction = System.Data.ParameterDirection.Input, Value = evento });
            ContexDb.ExecuteProcedure(command);
        }*/

        /// <summary>
        /// Obtiene las ordenes que se encuentren iniciadas.
        /// </summary>
        /*public static List<Orden> LeerOrdenesIniciadas()
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Ordenes_Iniciadas", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<Orden> ordenes = new List<Orden>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var orden = new Orden()
                        {
                            OrdenFabricacion = Convert.ToInt32(prodData["refOrden"])
                        };

                        ordenes.Add(orden);
                    }
                    return ordenes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }*/


        /// <summary>
        /// Verifica si una orden que se encuentra pausada.
        /// </summary>
        /*public static Boolean OrdenPausada(int Orden)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Orden_Pausada", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "OrdenFabricacion", Direction = System.Data.ParameterDirection.Input, Value = Orden });
                var datos = ContexDb.GetDataSet(command);
                List<Orden> ordenes = new List<Orden>();
                if (datos.Tables[0].Rows.Count == 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }*/


        /// <summary>
        /// Verifica si una orden que se encuentra pausada.
        /// </summary>
        /*public static Boolean OrdenPospuesta(int Orden)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Orden_Pospuesta", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "OrdenFabricacion", Direction = System.Data.ParameterDirection.Input, Value = Orden });
                var datos = ContexDb.GetDataSet(command);
                List<Orden> ordenes = new List<Orden>();
                if (datos.Tables[0].Rows.Count == 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }*/

        /// <summary>
        /// Verifica si una orden que se encuentra pausada.
        /// </summary>
        /*public static Boolean OrdenFinaliada(int Orden)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Orden_Finalizada", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "OrdenFabricacion", Direction = System.Data.ParameterDirection.Input, Value = Orden });
                var datos = ContexDb.GetDataSet(command);
                List<Orden> ordenes = new List<Orden>();
                if (datos.Tables[0].Rows.Count == 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }*/


        /**
         * Obtiene las ordenes del día
         **/
        public static List<Orden> LeerOrdenes(String fecha, int opcion)
        {
            try
            {
                String consulta = "";
                switch (opcion)
                {
                    case 1:
                        consulta = "Leer_Ordenes_Del_Día_Abierta";
                        break;
                    default:
                        consulta = "Leer_Ordenes_Planificadas";
                        break;
                }


                var command = new SqlCommand() { CommandText = consulta, CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = fecha });
                var datos = ContexDb.GetDataSet(command);
                List<Orden> ordenes = new List<Orden>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var orden = new Orden()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            OrdenFabricacion = Convert.ToInt32(prodData["ordenFabricacion"]),
                            Version = prodData["version"].ToString(),
                            Cliente = prodData["cliente"].ToString(),
                            SKU = prodData["sku"].ToString(),
                            Descripcion = prodData["descripcionSKU"].ToString(),
                            BotellasPlanificadas = Convert.ToInt32(prodData["botellasPlanificadas"]),
                            CajasPlanificadas = Convert.ToInt32(prodData["cajasPlanificadas"]),
                            FechaFabricacion = Convert.ToDateTime(prodData["fechaFabricacion"]),
                            FechaHoraInicio = Convert.ToDateTime(prodData["fechaHoraInicio"]),
                            FechaHoraTermino = Convert.ToDateTime(prodData["fechaHoraTermino"]),
                            FormatoCaja = prodData["formatoCaja"].ToString(),
                            Estado = Convert.ToInt32(prodData["estado"]),
                            Secuencia = Convert.ToInt32(prodData["secuencia"])
                        };

                        ordenes.Add(orden);
                    }
                    return ordenes;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /**
        * Obtiene las ordenes abiertas sin importar la fecha
        **/
        public static List<Orden> LeerOrdenesAbiertas()
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Ordenes_Abiertas", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<Orden> ordenes = new List<Orden>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var orden = new Orden()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            OrdenFabricacion = Convert.ToInt32(prodData["ordenFabricacion"]),
                            Version = prodData["version"].ToString(),
                            Cliente = prodData["cliente"].ToString(),
                            SKU = prodData["sku"].ToString(),
                            Descripcion = prodData["descripcionSKU"].ToString(),
                            BotellasPlanificadas = Convert.ToInt32(prodData["botellasPlanificadas"]),
                            CajasPlanificadas = Convert.ToInt32(prodData["cajasPlanificadas"]),
                            FechaFabricacion = Convert.ToDateTime(prodData["fechaFabricacion"]),
                            FechaHoraInicio = Convert.ToDateTime(prodData["fechaHoraInicio"]),
                            FechaHoraTermino = Convert.ToDateTime(prodData["fechaHoraTermino"]),
                            FormatoCaja = prodData["formatoCaja"].ToString(),
                            Estado = Convert.ToInt32(prodData["estado"]),
                            Secuencia = Convert.ToInt32(prodData["secuencia"])
                        };

                        ordenes.Add(orden);
                    }
                    return ordenes;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static List<Area> LeerAreas()
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Areas", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<Area> Areas = new List<Area>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var area = new Area()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Name = prodData["nombre"].ToString()
                        };

                        Areas.Add(area);
                    }
                    return Areas;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static int RegistrarIncidencia(int IdOrden, int IdIncidente, int IdArea, string EstadoOrden, DateTime FechaHoraInicio, string Observacion, double Progreso)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "InsertarIncidente", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdOrden", Direction = System.Data.ParameterDirection.Input, Value = IdOrden });
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdIncidente", Direction = System.Data.ParameterDirection.Input, Value = IdIncidente });
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdArea", Direction = System.Data.ParameterDirection.Input, Value = IdArea });
                command.Parameters.Add(new SqlParameter() { ParameterName = "EstadoOrden", Direction = System.Data.ParameterDirection.Input, Value = EstadoOrden });
                command.Parameters.Add(new SqlParameter() { ParameterName = "FechaHoraInicio", Direction = System.Data.ParameterDirection.Input, Value = FechaHoraInicio });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Observacion", Direction = System.Data.ParameterDirection.Input, Value = Observacion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Progreso", Direction = System.Data.ParameterDirection.Input, Value = Progreso });
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

        public static int FinalizarIncidencia(int IdOrden, DateTime FechaHoraTermino)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Finalizar_Incidencia", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdOrden", Direction = System.Data.ParameterDirection.Input, Value = IdOrden });
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

        public static List<Material> LeerMaterial(int IdOrden)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Material_1", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdOrden", Direction = System.Data.ParameterDirection.Input, Value = IdOrden });
                var datos = ContexDb.GetDataSet(command);
                List<Material> materiales = new List<Material>();
                //string format = "yyyy-MM-dd HH:mm:ss";
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var material = new Material()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            FechaHora = Convert.ToDateTime(prodData["fechaHora"]), //DateTime.ParseExact(prodData["fechaHora"].ToString(), format, CultureInfo.InvariantCulture),
                            Tipo = prodData["tipo"].ToString()
                        };
                        materiales.Add(material);
                    }
                    return materiales;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /*public static List<Botella> LeerBotellas(String Fecha, int OrdenFabricacion)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Botellas", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "OrdenFabricacion", Direction = System.Data.ParameterDirection.Input, Value = OrdenFabricacion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                var datos = ContexDb.GetDataSet(command);
                List<Botella> botellas = new List<Botella>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var botella = new Botella()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            HoraInicio = prodData["horaInicio"].ToString(),
                            HoraTermino = prodData["horaTermino"].ToString()
                        };

                        botellas.Add(botella);
                    }
                    return botellas;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }*/

        /*public static List<Caja> LeerCajas(String Fecha, int OrdenFabricacion)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Cajas", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "OrdenFabricacion", Direction = System.Data.ParameterDirection.Input, Value = OrdenFabricacion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                var datos = ContexDb.GetDataSet(command);
                List<Caja> cajas = new List<Caja>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var caja = new Caja()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Hora = prodData["hora"].ToString()
                        };

                        cajas.Add(caja);
                    }
                    return cajas;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }*/

        /*public static int LeerVelocidadBotellas(String Fecha, String Hora, int OrdenFabricacion)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Velocidad_Botellas", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "RefOrden", Direction = System.Data.ParameterDirection.Input, Value = OrdenFabricacion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Hora", Direction = System.Data.ParameterDirection.Input, Value = Hora });
                var datos = ContexDb.GetDataSet(command);
                int cantBotellasMin = 0;
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        if(prodData["cantBotellas"]!=null)
                        {
                            cantBotellasMin = Convert.ToInt32(prodData["cantBotellas"]);
                        }
                    }
                }
                return cantBotellasMin;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }*/

        /*public static int LeerVelocidadCajas(String Fecha, String Hora, int OrdenFabricacion)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Velocidad_Cajas", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "RefOrden", Direction = System.Data.ParameterDirection.Input, Value = OrdenFabricacion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Hora", Direction = System.Data.ParameterDirection.Input, Value = Hora });
                var datos = ContexDb.GetDataSet(command);
                int cantCajasMin = 0;
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        if (prodData["cantCajas"] != null)
                        {
                            cantCajasMin = Convert.ToInt32(prodData["cantCajas"]);
                        }
                    }
                }
                return cantCajasMin;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return 0;
        }*/

        public static int LeerVelocidadMaterial(string Fecha, string Hora, int OrdenFabricacion, string TipoMaterial)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Velocidad_Material_Actualizada", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdOrden", Direction = System.Data.ParameterDirection.Input, Value = OrdenFabricacion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Hora", Direction = System.Data.ParameterDirection.Input, Value = Hora });
                command.Parameters.Add(new SqlParameter() { ParameterName = "TipoMaterial", Direction = System.Data.ParameterDirection.Input, Value = TipoMaterial });
                var datos = ContexDb.GetDataSet(command);
                int cantTipoMaterial = 0;
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        if (prodData["cantTipoMaterial"] != null)
                        {
                            cantTipoMaterial = Convert.ToInt32(prodData["cantTipoMaterial"]);
                        }
                    }
                }
                return cantTipoMaterial;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
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
    }
}





