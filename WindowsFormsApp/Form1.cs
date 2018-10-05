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
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password = {ENTER PASSWORD HERE}; persistsecurityinfo = True; port = 3306; database = test; SslMode = none");
        int i;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM login WHERE loginUsername='" + textBox1.Text + "' AND loginPassword='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                label3.Text = "Incorrect username/password";
            }
            else
            {
                this.Hide();
                Form2 fm = new Form2();
                fm.Show();
            }

            conn.Close();
        }
    }
}
