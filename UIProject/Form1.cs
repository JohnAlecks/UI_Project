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
    public partial class LoginForm : Form
    {
        List<LoginInfo> LoginTable = new List<LoginInfo>();
        public LoginForm()
        {
            InitializeComponent();
            InitForm();
        }
        private void InitForm() {

            String appPath = Application.StartupPath;
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+appPath+"\\CriminalRecord.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(constring);
            
            string sql = "SELECT A.EmployeeID, A.Username,A.Password FROM LoginInfomation as A";
            SqlCommand com = new SqlCommand(sql, con);

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                LoginInfo temp = new LoginInfo();
                temp.EmployeeID = read.GetString(0).Trim();
                temp.Username = read.GetString(1).Trim();
                temp.Password = read.GetString(2).Trim();
                LoginTable.Add(temp);
            }
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool checkInfo(String username, String password) {
            try
            {
                if (LoginTable.Find(item => item.Username == username).Password.Equals(password))
                {
                    return true;
                }
            } catch (Exception e) {
                return false;
            }
            return false;           
        }
        private void loginBtn_Click(object sender, EventArgs e)
        {   
            if (checkInfo(usernameTextBox.Text, passwordTextBox.Text))
            {
                MessageBox.Show("Login Completed");
            }
            else {
                MessageBox.Show("Incorect username or password!!!");
            }
        }
    }
}
    

