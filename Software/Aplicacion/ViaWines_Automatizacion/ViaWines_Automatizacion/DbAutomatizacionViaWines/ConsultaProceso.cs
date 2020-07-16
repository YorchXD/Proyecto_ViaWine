using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViaWines_Automatizacion.Models;
using System.Globalization;

namespace ViaWines_Automatizacion.DbAutomatizacionViaWines
{
    public class ConsultaProceso
    {
        public static int ActualizarEstadoOrden(int OrdenFabricacion, int Estado)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Actualizar_Estado_Orden", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "OrdenFabricacion", Direction = System.Data.ParameterDirection.Input, Value = OrdenFabricacion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Estado", Direction = System.Data.ParameterDirection.Input, Value = Estado });
                ContexDb.ExecuteProcedure(command);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }

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
        }

        /// <summary>
        /// Obtiene las ordenes que se encuentren iniciadas.
        /// </summary>
        public static List<Orden> LeerOrdenesIniciadas()
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
        }


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
        public static List<Orden> LeerOrdenes(String fecha)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Ordenes_Del_Día", CommandType = System.Data.CommandType.StoredProcedure };
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
                            OrdenFabricacion = Convert.ToInt32(prodData["ordenFabricacion"]),
                            Version = prodData["version"].ToString(),
                            Cliente = prodData["cliente"].ToString(),
                            SKU = prodData["sku"].ToString(),
                            Descripcion = prodData["descripcionSKU"].ToString(),
                            BotellasPlanificadas = Convert.ToInt32(prodData["botellasPlanificadas"]),
                            CajasPlanificadas = Convert.ToInt32(prodData["cajasPlanificadas"]),
                            FechaFabricacion = prodData["fechaFabricacion"].ToString().Split(" ")[0],
                            HoraInicioPlanificada = prodData["horaInicioPlanificada"].ToString(),
                            HoraTerminoPlanificada = prodData["horaTerminoPlanificada"].ToString(),
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

        public static List<Material> LeerMaterial(String Fecha, int OrdenFabricacion)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Material", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "OrdenFabricacion", Direction = System.Data.ParameterDirection.Input, Value = OrdenFabricacion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
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
                var command = new SqlCommand() { CommandText = "Leer_Velocidad_Material", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "RefOrden", Direction = System.Data.ParameterDirection.Input, Value = OrdenFabricacion });
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
    }
}





