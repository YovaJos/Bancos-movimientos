using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Navegador.Utilidades;
using System.Collections;

namespace Movimiento_Bancos
{
    public partial class Form1 : Form
    {
        string NO_form = "";
        MySqlCommand cmd;
        MySqlConnection cn;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        DataTable dt;
        uspcombobox combo = new uspcombobox();

        public Form1()
        {
            InitializeComponent();
            combo.ComboMoneda(bancocmb);
            llenar();
        }

        //Estable la conexion a la base datos
        public static String stringpad = "server=localhost;user id=root; password=familia; database=hotelsancarlos";
        Conexion con = new Conexion(stringpad);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        //texto predictivo
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Conexion c = new Conexion(stringpad);
            c.OpenConnection();
            dataGridView1.DataSource = c.llenarDataGridView("select * from cuenta where no_cuenta like '" + nocuentaAtxt.Text + "%'");
            c.CloseConnection();
        }

        //verificar si establece conexion
        private void button1_Click(object sender, EventArgs e)
        {
            String stringpad = "server=localhost;user id=root; password=familia; database=hotelsancarlos";
            Conexion connection = new Conexion(stringpad);
            if (connection.OpenConnection())
            {
                MessageBox.Show("We are connected");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        //Texto predictivo para la cuenta
        private void nocuentaBtxt_TextChanged(object sender, EventArgs e)
        {
            Conexion c = new Conexion(stringpad);
            c.OpenConnection();
            dataGridView1.DataSource = c.llenarDataGridView("select * from cuenta where no_cuenta like '" + nocuentaBtxt.Text + "%'");
            c.CloseConnection();
        }

        //visualiza todos los datos de la tabla transaccion al iniciar el form
        public void llenar()
        {
            String stringpad = "server=localhost;user id=root; password=familia; database=hotelsancarlos";
            Conexion connection = new Conexion(stringpad);
            connection.OpenConnection();
            dataGridView2.DataSource = connection.llenarDataGridView("select * from transaccion");
            connection.CloseConnection();
        }

        private void navegador1_Load(object sender, EventArgs e)
        {

        }

        //insertar en la base datos desde el navegador
        private void navegador1_InsertReceive_1(object sender, EventArgs e)
        {
            String campo1 = notrantxt.Text;
            String campo2 = valortxt.Text;
            String campo3 = nocuentaAtxt.Text;
            String campo4 = bancocmb.Text;
            String campo5 = nocuentaBtxt.Text;
            String campo6 = movcmp.Text;
            String campo7 = fechadate.Text;
            ArrayList listavalores = new ArrayList();
            ArrayList listacampos = new ArrayList();

            listavalores.Add(0);
            listavalores.Add(campo1);
            listavalores.Add(campo2);
            listavalores.Add(campo3);
            listavalores.Add(campo4);
            listavalores.Add(campo5);
            listavalores.Add(campo6);
            listavalores.Add(campo7);
            listavalores.Add(0);

            listacampos.Add(notrantxt.Tag.ToString());
            listacampos.Add(valortxt.Tag.ToString());
            listacampos.Add(nocuentaAtxt.Tag.ToString());
            listacampos.Add(bancocmb.Tag.ToString());
            listacampos.Add(nocuentaBtxt.Tag.ToString());
            listacampos.Add(movcmp.Tag.ToString());
            listacampos.Add(fechadate.Tag.ToString());

            GeneradorSQL gsql = new GeneradorSQL("server", "bd", "user", "pass", "nametabla");
            gsql.setCodigoInstDML(1);
            gsql.setCampos(listacampos);
            gsql.setValores(listavalores);
            gsql.ejecutar();
        }
    }
}
