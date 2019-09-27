using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSysBank.DAL
{
    public class ComunBD
    {
        const string ConnectionString = @"Data Source=LEX-G7;Initial Catalog=BankDB;Integrated Security=True";

        public static IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static IDbCommand CreateCommand(IDbConnection conn, string sql = null)
        {
            IDbCommand comando = conn.CreateCommand();
            if (sql != null)
            {
                comando.CommandText = sql;
            }
            return comando;
        }

        public static int ExecuteNonQueryTransaction(IDbConnection conn, IDbCommand command)
        {
            int resultado = 0;
            conn.Open();
            using (IDbTransaction transaccion = conn.BeginTransaction())
            {
                try
                {
                    command.Transaction = transaccion;
                    resultado = command.ExecuteNonQuery();
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    resultado = 0;
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
            return resultado;
        }
    }
}
