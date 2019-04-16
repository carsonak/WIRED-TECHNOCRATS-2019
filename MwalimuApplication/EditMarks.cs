﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace MwalimuApplication
{
    public partial class EditMarks : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        
        public EditMarks()
        {
            InitializeComponent();
            connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Lynette\\source\\repos\\MwalimuApplication\\DataStudent.accdb; Persist Security Info=False";
        }

        private void EditMarks_Load(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Term1Marks";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["AdmissionNumber"].ToString());
            }
            
            connection.Close();
        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
           

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "update into Term1Marks set [AdmissionNumber]='" + bunifuMaterialTextbox9+ "',[Mathematics]='" + bunifuMaterialTextbox1.Text + "',[English]='" + bunifuMaterialTextbox2.Text + "',[Kiswahili]='" + bunifuMaterialTextbox3.Text + "',[Science]='" + bunifuMaterialTextbox4.Text + "',[SST/RE]='" + bunifuMaterialTextbox5.Text + "',[Average]='" + bunifuMaterialTextbox7.Text + "',[Total]='" + bunifuMaterialTextbox6.Text + "',[Grade]='" + bunifuMaterialTextbox8.Text + "' where [AdmissionNumber]='" + bunifuMaterialTextbox9 + "')";

                command.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
                connection.Close();
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Term1Marks where [AdmissionNumber]='" + comboBox1.Text + "'";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               
                bunifuMaterialTextbox1.Text = reader["Mathematics"].ToString();
                bunifuMaterialTextbox2.Text = reader["English"].ToString();
                bunifuMaterialTextbox3.Text = reader["Kiswahili"].ToString();
                bunifuMaterialTextbox4.Text = reader["Science"].ToString();
                bunifuMaterialTextbox5.Text = reader["SST/RE"].ToString();
                bunifuMaterialTextbox7.Text = reader["Total"].ToString();
                bunifuMaterialTextbox6.Text = reader["Average"].ToString();
                bunifuMaterialTextbox9.Text = reader["AdmissionNumber"].ToString();
                bunifuMaterialTextbox8.Text = reader["Grade"].ToString();
            }
            
            connection.Close();
        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {

        }
    }
    
}