using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Movimiento_Bancos
{
    class Conexion
    {
        private MySqlConnection conn;
        private String connStr;

        /*Create a constructor*/
        public Conexion(String coonection)
        {
            this.connStr = coonection;
        }

        /*Open a connection*/

        public bool OpenConnection()
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                /*Error of connection*/
                return false;
            }
        }

        /*Close the connection*/
        public bool CloseConnection()
        {
            try
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        public DataTable llenarDataGridView(String sentencia)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sentencia, connStr);
            da.Fill(dt);
            return dt;
        }

        public void InsertarRegistro(String sentencia)
        {
            string insertquery = sentencia;
            MySqlCommand command = new MySqlCommand(insertquery, conn);
            command.ExecuteNonQuery();
        }
    }
}