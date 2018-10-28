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
    public partial class Form3 : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password = {ENTER PASSWORD HERE}; persistsecurityinfo = True; port = 3306; database = test; SslMode = none");
        int i;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT loginQuestion FROM login WHERE loginUsername='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            string loginQuestion = String.Empty;
            if (i == 0)
            {
                label2.Text = "Username doesn't exist";
            }
            else
            {
                loginQuestion = dt.Rows[0]["loginQuestion"].ToString();
                this.Hide();
                Form4 fm = new Form4(loginQuestion);
                fm.Show();
            }

            conn.Close();
        }
    }
}
