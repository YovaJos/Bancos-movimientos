﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.Odbc;

namespace Movimiento_Bancos
{
    class Conexion
    {
        private OdbcConnection conn;
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
                conn = new OdbcConnection(connStr);
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
            catch (OdbcException ex)
            {
                return false;
            }
        }

        public DataTable llenarDataGridView(String sentencia)
        {
            DataTable dt = new DataTable();
            OdbcDataAdapter da = new OdbcDataAdapter(sentencia, connStr);
            da.Fill(dt);
            return dt;
        }

        public void InsertarRegistro(String sentencia)
        {
            string insertquery = sentencia;
            OdbcCommand command = new OdbcCommand(insertquery, conn);
            command.ExecuteNonQuery();
        }
    }
}