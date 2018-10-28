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

namespace WindowsFormsApp
{
    public partial class Form4 : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password = {ENTER PASSWORD HERE}; persistsecurityinfo = True; port = 3306; database = test; SslMode = none");
        int i;

        public Form4(string text)
        {
            InitializeComponent();
            label1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT loginPassword FROM login WHERE loginAnswer='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            string loginPassword = String.Empty;
            if (i == 0)
            {
                label2.Text = "Invalid answer";
            }
            else
            {
                loginPassword = dt.Rows[0]["loginPassword"].ToString();
                label2.Text = "Your password is " + loginPassword;
            }

            conn.Close();
        }
    }
}
