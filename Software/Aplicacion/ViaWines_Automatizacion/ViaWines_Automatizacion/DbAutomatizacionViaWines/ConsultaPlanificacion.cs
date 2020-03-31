using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViaWines_Automatizacion.Models;

namespace ViaWines_Automatizacion.DbAutomatizacionViaWines
{
    public class ConsultaPlanificacion
    {
        public static List<Orden> LeerOrdenes(String fecha)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Ordenes", CommandType = System.Data.CommandType.StoredProcedure };
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
                            BotellasFabricadas = 0,
                            CajasPlanificadas = Convert.ToInt32(prodData["cajasPlanificadas"]),
                            CajasFabricadas = 0,
                            FechaFabricacion = Convert.ToDateTime(prodData["fechaFabricacion"]),
                            HoraInicioPlanificada = Convert.ToDateTime(prodData["horaInicioPlanificada"].ToString()),
                            HoraTerminoPlanificada = Convert.ToDateTime(prodData["horaTerminoPlanificada"].ToString()),
                            FormatoCaja = prodData["formatoCaja"].ToString(),
                            Estado = Convert.ToInt32(prodData["estado"]),
                            Secuencia = Convert.ToInt32(prodData["secuencia"]),
                            PorcentajeAvance = 0
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
            finally
            {

            }
            return null;
        }
    }
}