using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSysBank.DAL;
using TestSysBank.EN;

namespace TestSysBank.BL
{
    public class ClienteBL
    {
        public static int Insert(Cliente cliente)
        {
            if (cliente != null)
            {
                string sql = string.Format("INSERT INTO Cliente(Nombre, Apellido)VALUES('{0}', '{1}')", cliente.Nombre, cliente.Apellido);
                IDbConnection conn = ComunBD.CreateConnection();
                IDbCommand comando = ComunBD.CreateCommand(conn, sql);
                return ComunBD.ExecuteNonQueryTransaction(conn, comando);
            }
            return 0;
        }

        public static int Update(Cliente cliente)
        {
            if (cliente != null)
            {
                string sql = string.Format("UPDATE Cliente SET Nombre='{0}', Apellido='{1}' WHERE IdCliente={2}", cliente.Nombre, cliente.Apellido, cliente.IdCliente);
                IDbConnection conn = ComunBD.CreateConnection();
                IDbCommand comando = ComunBD.CreateCommand(conn, sql);
                return ComunBD.ExecuteNonQueryTransaction(conn, comando);
            }
            return 0;
        }

        public static int Delete(long? id)
        {
            if (id != null)
            {
                string sql = string.Format("DELETE Cliente WHERE IdCliente={0}", id);
                IDbConnection conn = ComunBD.CreateConnection();
                IDbCommand comando = ComunBD.CreateCommand(conn, sql);
                return ComunBD.ExecuteNonQueryTransaction(conn, comando);
            }
            return 0;
        }

        public static List<Cliente> GetAll()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (IDbConnection conn = ComunBD.CreateConnection())
            {
                conn.Open();
                IDbCommand commando = ComunBD.CreateCommand(conn, "SELECT * FROM Cliente");
                IDataReader reader = commando.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        IdCliente = reader.GetInt64(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2)
                    };
                    clientes.Add(cliente);
                }
                conn.Close();
            }
            return clientes;
        }

        public static Cliente GetById(long? id)
        {
            if (id == null)
            {
                return null;
            }
            Cliente cliente = new Cliente();
            using (IDbConnection conn = ComunBD.CreateConnection())
            {
                conn.Open();
                IDbCommand commando = ComunBD.CreateCommand(conn, string.Format("SELECT * FROM Cliente WHERE IdCliente={0}", id));
                IDataReader reader = commando.ExecuteReader();
                while (reader.Read())
                {
                    cliente.IdCliente = reader.GetInt64(0);
                    cliente.Nombre = reader.GetString(1);
                    cliente.Apellido = reader.GetString(2);
                }
                conn.Close();
            }
            return cliente;
        }
    }
}
