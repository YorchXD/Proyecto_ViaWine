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
    public class ConsultaResumen
    {
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
                            Secuencia = Convert.ToInt32(prodData["secuencia"]),
                            FechaHoraInicio = Convert.ToDateTime(prodData["fechaHoraInicio"]),
                            FechaHoraTermino = Convert.ToDateTime(prodData["fechaHoraTermino"]),
                            PorcentajeAvance = 0,
                            CajasFabricadas = 0,
                            BotellasFabricadas = 0

                        };

                        int CantBotellas = LeerCantBotellas(fecha, orden.OrdenFabricacion);
                        int CantCajas = LeerCantCajas(fecha, orden.OrdenFabricacion);

                        if (CantBotellas != -1)
                        {
                            orden.BotellasFabricadas = CantBotellas;
                            orden.PorcentajeAvance = Math.Round((double)((CantBotellas * 100.0) / orden.BotellasPlanificadas), 2);
                        }

                        if (CantCajas != -1)
                        {
                            orden.CajasFabricadas = CantCajas;
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
            finally
            {

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
            finally
            {

            }
            return -1;
        }

        /*public static VelocidadProceso LeerVelocidad(String Fecha, String Hora, int OrdenFabricacion)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Velocidad", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "RefOrden", Direction = System.Data.ParameterDirection.Input, Value = OrdenFabricacion });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Hora", Direction = System.Data.ParameterDirection.Input, Value = Hora });
                var datos = ContexDb.GetDataSet(command);
                VelocidadProceso velocidad = new VelocidadProceso() { Fecha = Fecha, Hora = Hora, cantBotellas = 0, cantCajas = 0 };
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        if (prodData["cantBotellas"] != null)
                        {
                            velocidad.cantBotellas = Convert.ToInt32(prodData["cantBotellas"]);
                        }

                        if (prodData["cantCajas"] != null)
                        {
                            velocidad.cantCajas = Convert.ToInt32(prodData["cantCajas"]);
                        }
                    }
                }
                return velocidad;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }*/

        /**
         * Obtiene los el total de botellas fabricadas hasta el momento de la consulta y el total de botellas a fabricar.
         * Devuelve un listado de los datos en donde la posicion 0 es la cantidad de botellas fabricadas hasta el momento
         * y la posicion 1 es la cantidad de botellas planificadas a producir. En caso que se produzca un error se envía null
         **/
        public static List<int> LeerCantBotellasDia(String Fecha)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Cant_Botellas_Dia", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                var datos = ContexDb.GetDataSet(command);
                List<int> indicadorBotella = new List<int>{ 0,0};

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        indicadorBotella[0] = Convert.ToInt32(prodData["cantBotellas"]);
                        indicadorBotella[1] = Convert.ToInt32(prodData["totalBotellasPlanificadas"]);
                    }

                }
                return indicadorBotella;

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

        /**
         * Obtiene el total de cajas fabricadas hasta el momento de la consulta y el total de cajas a fabricar.
         * Devuelve un listado de los datos en donde la posicion 0 es la cantidad de cajas fabricadas hasta el momento
         * y la posicion 1 es la cantidad de cajas planificadas a producir. En caso que se produzca un error se envía null
         **/
        public static List<int> LeerCantCajasDia(String Fecha)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Cant_Cajas_Dia", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                var datos = ContexDb.GetDataSet(command);
                List<int> indicadorCaja = new List<int> { 0, 0 };

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        indicadorCaja[0] = Convert.ToInt32(prodData["cantCajas"]);
                        indicadorCaja[1] = Convert.ToInt32(prodData["totalCajasPlanificadas"]);
                    }

                }
                return indicadorCaja;

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
                List<int> indicadorOrdenesFinalizadas= new List<int> { 0, 0 };

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
            finally
            {

            }
            return null;
        }

        /*public static List<Objeto> LeerCantBotellasHora(String Fecha)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Cant_Botellas_Por_Hora", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "Fecha", Direction = System.Data.ParameterDirection.Input, Value = Fecha });
                var datos = ContexDb.GetDataSet(command);
                List<Objeto> ListaBotellasHora = null;

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var cantBotellasHora = new Objeto()
                        {
                            Hora = prodData["hora"].ToString(),
                            Cantidad = Convert.ToInt32(prodData["cantBotellas"])
                        };
                        ListaBotellasHora.Add(cantBotellasHora);
                    }

                }
                return ListaBotellasHora;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

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
                        if (prodData["cantBotellas"] != null)
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
            return -1;
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
    }
}

