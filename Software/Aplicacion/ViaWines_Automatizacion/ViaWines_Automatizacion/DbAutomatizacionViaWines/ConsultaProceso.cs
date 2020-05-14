using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViaWines_Automatizacion.Models;

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
        public static Boolean OrdenPausada(int Orden)
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
        }


        /// <summary>
        /// Verifica si una orden que se encuentra pausada.
        /// </summary>
        public static Boolean OrdenPospuesta(int Orden)
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
        }

        /// <summary>
        /// Verifica si una orden que se encuentra pausada.
        /// </summary>
        public static Boolean OrdenFinaliada(int Orden)
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
        }

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
    }
}





