using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ViaWines_Automatizacion.DbAutomatizacionViaWines
{
    public class ContexDb
    {
        private static string connStr = "server=190.171.160.83;database=Automatizacion_ViaWines3.0;UID=sa;PASSWORD=J1h4m3b012*;";

        public static DataSet GetDataSet(SqlCommand command)
        {
            var ds = new DataSet();
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                command.Connection = conn;
                var sqlda = new SqlDataAdapter(command);
                sqlda.Fill(ds);
                conn.Close();
            }
            return ds;
        }

        /*
         * Ejecuta el commando y lo retorna (en caso de que se requiera revisar parametros de salida).
         * El comando tiene que corresponder con algún procedure existente en la base de datos.
         */
        public static SqlCommand ExecuteProcedure(SqlCommand command)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sqlTran = conn.BeginTransaction();
                try
                {
                    command.Connection = conn;
                    command.Transaction = sqlTran;
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    Console.WriteLine(ex.ToString());
                    command = null;
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
            return command;
        }  
    } 
}

