using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIProject
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
            getData();
        }
        String id = "";
        private void getData() {
            
            String appPath = Application.StartupPath;
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + appPath + "\\CriminalRecord.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(constring);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string sql = "SELECT A.EmployeeID, A.RealName, A.Address FROM UserInformation as A";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader read = command.ExecuteReader();
            
            
            while (read.Read())
            {
                UserInfo temp = new UserInfo();
                temp.RealName = read.GetString(1).Trim();
                temp.Address = read.GetString(2).Trim();
                comboBox1.Items.Add(temp.RealName);
                id = temp.EmployeeID = read.GetString(0).Trim();

            }
            con.Close();

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            String appPath = Application.StartupPath;
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + appPath + "\\CriminalRecord.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(constring);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string sql = "INSERT INTO dbo.LoginInfomation (EmployeeID, Username, Password) VALUES (@id, @Username, @Password)";
            SqlCommand command = new SqlCommand(sql, con);
            command.Parameters.Add("@username", "abc");
            command.Parameters.Add("@password", "abc");
            command.Parameters.Add("@id", id);
            command.ExecuteNonQuery();

            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
