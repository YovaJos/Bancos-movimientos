using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.Odbc;

namespace Movimiento_Bancos
{
    class uspcombobox
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root; password=familia; database=hotelsancarlos");
        public void ComboBanco(ComboBox codarocmb)
        {
            codarocmb.Items.Clear();
            con.Open();
            MySqlCommand cmD = new MySqlCommand("SELECT * FROM banco", con);
            MySqlDataReader drd = cmD.ExecuteReader();
            while (drd.Read())
            {
                codarocmb.Items.Add(drd[1].ToString());
            }
            con.Close();
            codarocmb.Items.Insert(0, "--Seleccione--");
            codarocmb.SelectedIndex = 0;
        }
        public void Combomovimiento(ComboBox codarocmb)
        {
            codarocmb.Items.Clear();
            con.Open();
            MySqlCommand cmD = new MySqlCommand("SELECT * FROM movimiento", con);
            MySqlDataReader drd = cmD.ExecuteReader();
            while (drd.Read())
            {
                codarocmb.Items.Add(drd[1].ToString());
            }
            con.Close();
            codarocmb.Items.Insert(0, "--Seleccione--");
            codarocmb.SelectedIndex = 0;
        }
        public void Combomoneda(ComboBox codarocmb)
        {
            codarocmb.Items.Clear();
            con.Open();
            MySqlCommand cmD = new MySqlCommand("SELECT * FROM moneda", con);
            MySqlDataReader drd = cmD.ExecuteReader();
            while (drd.Read())
            {
                codarocmb.Items.Add(drd[1].ToString());
            }
            con.Close();
            codarocmb.Items.Insert(0, "--Seleccione--");
            codarocmb.SelectedIndex = 0;
        }
    }
}
