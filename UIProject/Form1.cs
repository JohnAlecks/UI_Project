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
using UIProject.Securities;
using static UIProject.Securities.Cookies;

namespace UIProject
{
    public partial class LoginForm : Form
    {
        bool flag = false;
        List<LoginInfo> LoginTable = new List<LoginInfo>();
        public LoginForm()
        {
            InitializeComponent();
            InitForm();
        }
        private void InitForm() {

            String appPath = Application.StartupPath;
            Console.WriteLine(appPath + "Hello");
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+appPath+"\\CriminalRecord.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(constring);
            
            string sql = "SELECT UserInfo_ID, Email, Password FROM LoginInformation, UserInformations WHERE UserInfo_ID = User_Login_ID";
            SqlCommand com = new SqlCommand(sql, con);

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                LoginInfo temp = new LoginInfo();
                temp.UserLogin = read.GetInt32(0);
                Console.WriteLine(temp.UserLogin);
                temp.Email = read.GetString(1).Trim();
                Console.WriteLine(temp.Email);
                temp.Password = read.GetString(2).Trim();
                LoginTable.Add(temp);
            }
            con.Close();
        }
        private bool checkRecord(string email, string box) {
            try {
                LoginInfo temp = LoginTable.Find(item => item.Email == email);
                Console.Write(temp.Password);
                if (SaltPassword.VerifyHash("JohnWick", "SHA512", temp.Password) == true)
                {
                    SessionInfo.UserID = temp.UserLogin;
                    Console.WriteLine(SessionInfo.UserID);
                    return true;
                }
                else {
                    return false;
                };

                
            } catch (Exception e) {
                Console.WriteLine(e);
            }
            return false;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void loginBtn_Click(object sender, EventArgs e)
        {   
            if (checkRecord(usernameTextBox.Text, passwordTextBox.Text) == true)
            {
                MessageBox.Show("Login Completed");
            }
            else {
                MessageBox.Show("Incorect username or password!!!");
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            SignUpForm signup = new SignUpForm();
            signup.Show();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    

