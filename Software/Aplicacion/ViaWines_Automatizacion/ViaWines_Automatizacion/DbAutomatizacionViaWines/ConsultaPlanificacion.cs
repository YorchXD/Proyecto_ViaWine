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
    public class ConsultaPlanificacion
    {
        public static List<Orden> LeerOrdenes(String fecha, int opcion)
        {
            try
            {
                String PA = null;
                switch(opcion)
                {
                    case 1:
                        PA = "Leer_Ordenes_Del_Día_Abierta";
                        break;
                    case 2:
                        PA = "Leer_Ordenes_Planificadas";
                        break;
                    default:
                        DateTime fechaConsulta = Convert.ToDateTime(fecha).Date;
                        DateTime fechaActual = DateTime.Now.Date;
                        if (fechaConsulta<=fechaActual)
                        {
                            PA = "Leer_Ordenes_Del_Día";
                        }
                        else
                        {
                            PA = "Leer_Ordenes_Planificadas";
                        }
                        break;
                }

                var command = new SqlCommand() { CommandText = PA, CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = fecha });
                var datos = ContexDb.GetDataSet(command);
                List<Orden> ordenes = new List<Orden>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        Orden orden = new Orden()
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
                            HoraInicioPlanificada = prodData["horaInicioPlanificada"].ToString(),
                            HoraTerminoPlanificada = prodData["horaTerminoPlanificada"].ToString(),
                            FechaHoraInicio = Convert.ToDateTime(prodData["fechaHoraInicio"]),
                            FechaHoraTermino = Convert.ToDateTime(prodData["fechaHoraTermino"]),
                            FormatoCaja = prodData["formatoCaja"].ToString(),
                            Estado = Convert.ToInt32(prodData["estado"]),
                            Secuencia = Convert.ToInt32(prodData["secuencia"]),
                            PorcentajeAvance = 0
                        };

                    

                        int CantBotellas = LeerCantBotellas(fecha, orden.OrdenFabricacion);
                        int CantCajas = LeerCantCajas(fecha, orden.OrdenFabricacion);

                        if (CantCajas != -1)
                        {
                            orden.BotellasFabricadas = CantBotellas;
                        }

                        if (CantCajas!=-1)
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




        public static List<String> LeerFechas()
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Fechas_Planificadas", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<String> fechas = new List<String>();

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        DateTime fecha = Convert.ToDateTime(prodData["fechaFabricacion"]);
                        String FechaFabricacion = fecha.Month+"/"+fecha.Day+"/"+fecha.Year;
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

        public static List<String> LeerFechasPasadas()
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Fechas_Planificadas_Realizadas", CommandType = System.Data.CommandType.StoredProcedure };
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

        public static int LeerCantCajas(String Fecha, int OrdenFabricacion)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Cantidad_Cajas", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "OrdenFabricacion", Direction = System.Data.ParameterDirection.Input, Value = OrdenFabricacion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                var datos = ContexDb.GetDataSet(command);
                int cantCajas = 0;

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        cantCajas = Convert.ToInt32(prodData["cantCajas"]);
                    }
                    
                }
                return cantCajas;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return -1;
        }

        public static int LeerCantBotellas(String Fecha, int OrdenFabricacion)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Cantidad_Botellas", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "OrdenFabricacion", Direction = System.Data.ParameterDirection.Input, Value = OrdenFabricacion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                var datos = ContexDb.GetDataSet(command);
                int cantCajas = 0;

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        cantCajas = Convert.ToInt32(prodData["cantBotellas"]);
                    }

                }
                return cantCajas;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return -1;
        }

        public static Boolean AgregarNuevasOrdenes(int OrdenFabricacion, String Fecha)
        {
            Boolean validar = false;
            try
            {
                var command = new SqlCommand() { CommandText = "AgregarUnaOrdenFutura", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "OrdenFabricacion", Direction = System.Data.ParameterDirection.Input, Value = OrdenFabricacion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    var prodData = datos.Tables[0].Rows[0];
                    int refOrden = Convert.ToInt32(prodData["refOrden"]);
                    if(refOrden==OrdenFabricacion)
                    {
                        validar = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return validar;
        }

        public static List<String> LeerFechasOrdenesPlanificadas()
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
    }
}


