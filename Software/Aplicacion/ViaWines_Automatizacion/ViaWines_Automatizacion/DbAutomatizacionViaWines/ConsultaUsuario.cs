using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViaWines_Automatizacion.Models;

namespace ViaWines_Automatizacion.DbAutomatizacionViaWines
{
    public class ConsultaUsuario
    {
        public static Usuario IniciarSesion(string email)
        {

            try
            {
                var command = new SqlCommand() { CommandText = "Iniciar_Sesion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "Email", Direction = System.Data.ParameterDirection.Input, Value = email });
                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count == 1)
                {
                    var aux = datos.Tables[0].Rows[0];
                    Usuario usuario = new Usuario()
                    {
                        Id = Convert.ToInt32(aux["id"]),
                        Email = aux["email"].ToString(),
                        Nombre = aux["nombre"].ToString(),
                        IdRol = Convert.ToInt32(aux["refRol"]),
                        Cargo = aux["cargo"].ToString()
                    };

                    return usuario;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }


        public static int Leer_Rol_Operacion(String idRolUsuario, int idOperacion)
        {
            int cantOperaciones = 0;
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Rol_Operacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "RefRolUsuario", Direction = System.Data.ParameterDirection.Input, Value = idRolUsuario });
                command.Parameters.Add(new SqlParameter() { ParameterName = "RefOperacion", Direction = System.Data.ParameterDirection.Input, Value = idOperacion });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count > 0)
                {
                    cantOperaciones = datos.Tables[0].Rows.Count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                cantOperaciones = -1;
            }

            return cantOperaciones;
        }
        public static Operacion Leer_Operacion(int idOperacion)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Operacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "RefOperacion", Direction = System.Data.ParameterDirection.Input, Value = idOperacion });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count > 0)
                {
                    Operacion operacion = new Operacion()
                    {
                        Id = Convert.ToInt32(datos.Tables[0].Rows[0]["id"]),
                        IdControlador = Convert.ToInt32(datos.Tables[0].Rows[0]["refControlador"]),
                        Nombre = datos.Tables[0].Rows[0]["nombre"].ToString()
                    };
                    return operacion;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static Controlador Leer_Controlador(int idControlador)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Controlador", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "RefControlador", Direction = System.Data.ParameterDirection.Input, Value = idControlador });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count > 0)
                {
                    Controlador controlador = new Controlador()
                    {
                        Id = Convert.ToInt32(datos.Tables[0].Rows[0]["id"]),
                        Nombre = datos.Tables[0].Rows[0]["nombre"].ToString()
                    };
                    return controlador;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }


        /**
         * Funciones aun sin ocupar
         **/

        /*public static String Leer_Correo(string Email)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "leer_Correo", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "in_email", Direction = System.Data.ParameterDirection.Input, Value = Email });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    System.Data.DataRow row = datos.Tables[0].Rows[0];
                    var prodData = row;
                    return prodData["email"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }*/

    }
}
