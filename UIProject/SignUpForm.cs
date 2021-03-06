﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIProject.Securities;

namespace UIProject
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
            getData();
        }
        int id;
        private void getData() {
            
            String appPath = Application.StartupPath;
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + appPath + "\\CriminalRecord.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(constring);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string sql = "SELECT A.UserInfo_ID, A.Fullname, A.Address FROM UserInformations as A";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader read = command.ExecuteReader();
            
            
            while (read.Read())
            {
                UserInfo temp = new UserInfo();
                temp.Fullname = read.GetString(1).Trim();
                temp.Address = read.GetString(2).Trim();
                comboBox1.Items.Add(temp.Fullname);
                id = temp.UserInfoID = read.GetInt32(0);

            }
            con.Close();

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            String appPath = Application.StartupPath;
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + appPath + "\\CriminalRecord.mdf;Integrated Security=True;Connect Timeout=30";
            Console.WriteLine(appPath + "Hello");
            SqlConnection con = new SqlConnection(constring);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string sql = "INSERT INTO LoginInformation (User_Login_ID, Email, Password) VALUES (@id, @email, @password)";
            SqlCommand command = new SqlCommand(sql, con);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@email", SqlDbType.VarChar, 38).Value = "quangminh3@gmail.com";
            string ePass = SaltPassword.ComputeHash("JohnWick", "SHA512", null);
            Console.WriteLine(ePass);
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = ePass;
            command.ExecuteNonQuery();
            Console.WriteLine("COMPLETE");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
