using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Movimiento_Bancos
{
    class uspcombobox
    {
        MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password=familia; database=hotelsancarlos");
        public void ComboMoneda(ComboBox codarocmb)
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
    }
}
