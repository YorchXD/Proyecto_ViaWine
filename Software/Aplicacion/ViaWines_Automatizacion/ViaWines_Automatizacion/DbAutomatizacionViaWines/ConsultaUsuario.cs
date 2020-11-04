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
        public static Usuario IniciarSesion(string email, string clave)
        {

            try
            {
                var command = new SqlCommand() { CommandText = "Iniciar_Sesion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "Email", Direction = System.Data.ParameterDirection.Input, Value = email });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Clave", Direction = System.Data.ParameterDirection.Input, Value = clave });
                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count == 1)
                {
                    var aux = datos.Tables[0].Rows[0];
                    Usuario usuario = new Usuario()
                    {
                        Id = Convert.ToInt32(aux["id"]),
                        Email = aux["email"].ToString(),
                        Nombre = aux["nombre"].ToString(),
                        Cargo = aux["cargo"].ToString(),
                        IdRol = Convert.ToInt32(aux["refRol"]),
                        EstadoClave = aux["estadoClave"].ToString()
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

        public static int Resetear_Clave(int IdUsuario, string Clave)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Resetear_Clave", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdUsuario", Direction = System.Data.ParameterDirection.Input, Value = IdUsuario });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Clave", Direction = System.Data.ParameterDirection.Input, Value = Clave });
                var datos = ContexDb.ExecuteProcedure(command);
                return 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }

        public static int Editar_Perfil_Usuario(int IdUsuario, string Email, string Nombre, string Cargo, int RefRol)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Editar_Perfil_Usuario", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdUsuario", Direction = System.Data.ParameterDirection.Input, Value = IdUsuario });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Email", Direction = System.Data.ParameterDirection.Input, Value = Email });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Nombre", Direction = System.Data.ParameterDirection.Input, Value = Nombre });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Cargo", Direction = System.Data.ParameterDirection.Input, Value = Cargo });
                command.Parameters.Add(new SqlParameter() { ParameterName = "RefRol", Direction = System.Data.ParameterDirection.Input, Value = RefRol });
                var datos = ContexDb.GetDataSet(command);
                return Convert.ToInt32(datos.Tables[0].Rows[0]["confirmacion"]);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }

        public static int Editar_Mi_Perfil(int IdUsuario, string Nombre, string Cargo)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Editar_Mi_Perfil", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdUsuario", Direction = System.Data.ParameterDirection.Input, Value = IdUsuario });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Nombre", Direction = System.Data.ParameterDirection.Input, Value = Nombre });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Cargo", Direction = System.Data.ParameterDirection.Input, Value = Cargo });
                var datos = ContexDb.ExecuteProcedure(command);
                return 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }

        public static int Eliminar_Usuario(int IdUsuario)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Eliminar_Usuario", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdUsuario", Direction = System.Data.ParameterDirection.Input, Value = IdUsuario });
                var datos = ContexDb.ExecuteProcedure(command);
                return 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }

        public static int Actualizar_Clave(int id, string claveActual, string nuevaClave)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Actualizar_Clave", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "IdUsuario", Direction = System.Data.ParameterDirection.Input, Value = id });
                command.Parameters.Add(new SqlParameter() { ParameterName = "ClaveActual", Direction = System.Data.ParameterDirection.Input, Value = claveActual });
                command.Parameters.Add(new SqlParameter() { ParameterName = "NuevaClave", Direction = System.Data.ParameterDirection.Input, Value = nuevaClave });
                var datos = ContexDb.GetDataSet(command);
                return Convert.ToInt32(datos.Tables[0].Rows[0]["confirmacion"]);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
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

        public static List<Usuario> Leer_Usuarios()
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Usuarios", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<Usuario> usuarios = new List<Usuario>();
                int cantUsuarios = datos.Tables[0].Rows.Count;
                for (int i = 0; i < cantUsuarios; i++)
                {
                    Usuario usuario = new Usuario()
                    {
                        Id = Convert.ToInt32(datos.Tables[0].Rows[i]["id"]),
                        Nombre = datos.Tables[0].Rows[i]["nombre"].ToString(),
                        Email = datos.Tables[0].Rows[i]["email"].ToString(),
                        Cargo = datos.Tables[0].Rows[i]["cargo"].ToString(),
                        NombreRol = datos.Tables[0].Rows[i]["rol"].ToString()

                    };

                    usuarios.Add(usuario);
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static List<Rol> Leer_Roles()
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Leer_Rol", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<Rol> roles = new List<Rol>();
                int cantRoles = datos.Tables[0].Rows.Count;
                for (int i = 0; i < cantRoles; i++)
                {
                    Rol rol = new Rol()
                    {
                        Id = Convert.ToInt32(datos.Tables[0].Rows[i]["id"]),
                        Nombre = datos.Tables[0].Rows[i]["nombre"].ToString()

                    };

                    roles.Add(rol);
                }
                return roles;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static int Agregar_Usuario(String Email, String Nombre, String Cargo, int RefRol, String Clave)
        {
            try
            {
                var command = new SqlCommand() { CommandText = "Agregar_Usuario", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter() { ParameterName = "Email", Direction = System.Data.ParameterDirection.Input, Value = Email });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Nombre", Direction = System.Data.ParameterDirection.Input, Value = Nombre });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Cargo", Direction = System.Data.ParameterDirection.Input, Value = Cargo });
                command.Parameters.Add(new SqlParameter() { ParameterName = "RefRol", Direction = System.Data.ParameterDirection.Input, Value = RefRol });
                command.Parameters.Add(new SqlParameter() { ParameterName = "Clave", Direction = System.Data.ParameterDirection.Input, Value = Clave });
                var datos = ContexDb.GetDataSet(command);
                return Convert.ToInt32(datos.Tables[0].Rows[0]["id"]);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
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
