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
        private String departmentName;
        private String location;
        private String departmentID;

        public String DepartmentID {
            get {
                return departmentID;
            }

            set {
                departmentID = value;
            }
        }
        public String DepartmentName {
            get {
                return departmentName;
            }
            set {
                departmentName = value;
            }
        }

        public String Location {
            get {
                return location;
            }

            set {
                location = value;
            }
        }

    }

    class UserInfo {
        private String realname;
        private String address;
        private String employeeID;

       public String RealName {
            get {
                return realname;
            }
            set {
                realname = value;
            }

        }

        public String Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }

        }

        public String EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
            }

        }

    }
}
