﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp.Auth;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        static CredentialContext credentialContext = new CredentialContext();
        MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password = " + credentialContext.MySQL_Password + "; persistsecurityinfo = True; port = 3306; database = test; SslMode = none");
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
                textBox1.Text = textBox1.Text.Substring(0, 1).ToUpper() + textBox1.Text.Substring(1);
                Form2 fm = new Form2(textBox1.Text);
                fm.Show();
            }

            conn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 fm3 = new Form3();
            fm3.Show();
        }
    }
}   
