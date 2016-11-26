using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIProject
{
    class LoginInfo {
        private String username;
        private String password;
        private String employeeID;
        public String Username {
               get {
                return username;
            }
               set {
                if (value != null && value != "") {
                    username = value;
                }
            }
        }
        
        public String Password {
             get {
                return password;
            }
            set {
                if (value.ToString().Length > 6)
                {
                    password = value;
                }
                else {
                    throw (new PasswordIsTooShort("Password is too short. Password must be longer than 6 characters"));
                }
            }
        }
        public String EmployeeID {
                get {
                return employeeID;
            }
                set {
                employeeID = value;
            }
        }
    }
    class Deparment {

    }

    class UserInfo {

    }

}
