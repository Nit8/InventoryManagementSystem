﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace InventoryManagementSystem
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Projects\\InventoryManagementSystem\\inventory.mdf;Integrated Security=True");
        
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int i = 0;
            SqlCommand cmd=conn.CreateCommand();
            cmd.CommandType=CommandType.Text;
            cmd.CommandText = "select * from registration where username ='"+textBox1.Text+"' and password='"+textBox2.Text+"'";
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            cmd.ExecuteNonQuery();
            DataTable dt =new DataTable();
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            da.Fill(dt);
            i= Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("This username doesnt exist");

            }
            else
            {
                this.Hide();
                MDIParent1 mdi =new MDIParent1();
                mdi.Show();
            }



        }
    }
}
