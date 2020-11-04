using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ViaWines_Automatizacion.Models;

namespace ViaWines_Automatizacion.DbAutomatizacionViaWines
{
    public class ConsultaResumen
    {
        /*SE DEBE MODIFICAR*/
        public static List<String> LeerFechasOrdenes()
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Fechas_Resumen", CommandType = System.Data.CommandType.StoredProcedure };
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

        /**
         * Obtiene las ordenes del día (MODIFICADA)
         **/
        public static List<Orden> LeerOrdenes(String fecha)
        {
            try
            {
                //var command = new SqlCommand() { CommandText = "Leer_Ordenes_Del_Día", CommandType = System.Data.CommandType.StoredProcedure };
                var command = new SqlCommand() { CommandText = "Leer_Ordenes_Resumen", CommandType = System.Data.CommandType.StoredProcedure };

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
                            HoraInicioPlanificada = prodData["horaInicioPlanificada"].ToString(),
                            HoraTerminoPlanificada = prodData["horaTerminoPlanificada"].ToString(),
                            FormatoCaja = prodData["formatoCaja"].ToString(),
                            Estado = Convert.ToInt32(prodData["estado"]),
                            Secuencia = Convert.ToInt32(prodData["secuencia"]),
                            FechaHoraInicio = Convert.ToDateTime(prodData["fechaHoraInicio"]),
                            FechaHoraTermino = Convert.ToDateTime(prodData["fechaHoraTermino"]),
                            Formato = prodData["formatoCaja"].ToString(),
                            PorcentajeAvance = 0,
                            CajasFabricadas = 0,
                            BotellasFabricadas = 0

                        };

                        int CantBotellas = LeerCantMaterial(fecha, orden.OrdenFabricacion, "Botella");
                        int CantCajas = LeerCantMaterial(fecha, orden.OrdenFabricacion, "Caja");

                        if (CantBotellas != -1)
                        {
                            orden.BotellasFabricadas = CantBotellas;

                        }

                        if (CantCajas != -1)
                        {
                            orden.CajasFabricadas = CantCajas;
                            orden.PorcentajeAvance = Math.Round((double)((CantCajas * 100.0) / orden.CajasPlanificadas), 2);
                        }

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
         * IMPLEMENTADA
         * Obtiene la cantidad de botellas o cajas contabilizadas segun el día, la orden de fabricación y el tipo.
         * El tipo indica si es botella o cajas el material a contabilizar
         */
        public static int LeerCantMaterial(String Fecha, int OrdenFabricacion, String Tipo)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Cantidad_Material", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "OrdenFabricacion", Direction = System.Data.ParameterDirection.Input, Value = OrdenFabricacion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Tipo", Direction = System.Data.ParameterDirection.Input, Value = Tipo });
                var datos = ContexDb.GetDataSet(command);
                int cantMaterial = 0;

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        cantMaterial = Convert.ToInt32(prodData["cantMaterial"]);
                    }

                }
                return cantMaterial;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }

        /**
         * IMPLEMENTADA
         * Obtiene el total de cajas o botellas fabricadas hasta el momento de la consulta y el total de cajas o botellas a fabricar.
         * Devuelve un listado de los datos en donde la posicion 0 es la cantidad de cajas o cajsa fabricadas hasta el momento
         * y la posicion 1 es la cantidad de cajas o botellas planificadas a producir. En caso que se produzca un error se envía null
         * 
         * tipo puede ser 1 cuando es botellas o 2 cuando es cajas
         */
        public static List<int> LeerCantMaterialDia(String Fecha, String Tipo)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Cant_Material_Dia", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Tipo", Direction = System.Data.ParameterDirection.Input, Value = Tipo });
                var datos = ContexDb.GetDataSet(command);
                List<int> indicadorMaterial = new List<int> { 0, 0 };

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        indicadorMaterial[0] = Convert.ToInt32(prodData["cantMaterial"]);
                        indicadorMaterial[1] = Convert.ToInt32(prodData["totalMaterialPlanificado"]);
                    }

                }
                return indicadorMaterial;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }



        /**
         * Obtiene el total de ordenes finalizadas hasta el momento de la consulta y el total de ordenes a realizar.
         * Devuelve un listado de los datos en donde la posicion 0 es la cantidad de ordenes finalizadas hasta el momento
         * y la posicion 1 es la cantidad de ordenes a producir. En caso que se produzca un error se envía null
         **/
        public static List<int> LeerOrdenesTerminadasDia(String Fecha)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Cant_Ordenes_Finalizadas_Dia", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                var datos = ContexDb.GetDataSet(command);
                List<int> indicadorOrdenesFinalizadas = new List<int> { 0, 0 };

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        indicadorOrdenesFinalizadas[0] = Convert.ToInt32(prodData["ordenesFinalizadas"]);
                        indicadorOrdenesFinalizadas[1] = Convert.ToInt32(prodData["total"]);
                    }

                }
                return indicadorOrdenesFinalizadas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

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

        /**
         * IMPLEMENTADA
         * Obtiene la cantidad de botellas y cajas contabilizada por minuto o por hora segun sea el caso
         * Para determinar si se obtiene la cantidad de material por minuto o por hora se considera la orden de fabricacion
         * Si el id de orden de fabricacion es -1 significa que se pide la cantidad de material por hora
         * Si el id de la orden de fabricacion es distinta de -1 significa que se pide la cantidad de material por minuto
         */
        public static List<Monitoreo> LeerMonitoreo(String Fecha, int IdOrden)
        {

            try
            {
                SqlCommand command;

                if (IdOrden != -1)
                {
                    command = new SqlCommand() { CommandText = "Cant_Bot_Caj_Min_Orden_Act", CommandType = System.Data.CommandType.StoredProcedure };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "refOrden", Direction = System.Data.ParameterDirection.Input, Value = IdOrden });
                }
                else
                {
                    command = new SqlCommand() { CommandText = "Cant_Bot_Caj_Hora_Orden", CommandType = System.Data.CommandType.StoredProcedure };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                }

                var datos = ContexDb.GetDataSet(command);
                List<Monitoreo> monitoreos = new List<Monitoreo>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var monitoreo = new Monitoreo()
                        {
                            Hora = prodData["hora"].ToString(),
                            Botellas = Convert.ToInt32(prodData["botellas"]),
                            Cajas = Convert.ToInt32(prodData["cajas"])
                        };

                        monitoreos.Add(monitoreo);
                    }
                    return monitoreos;
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