using EmployeeManagementDALibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDALibrary
{
    public class User
    {
        private string _password;
        public string Username { get; set; }
        public string Password
        {
            get
            {
                string maskedPass = "";
                foreach (var item in _password)
                {
                    maskedPass += "*";
                }
                return maskedPass;
            }
            set
            {
                _password = value;
            }
        }
        public string Role { get; set; }
        public bool PasswordCompare(string userPassword)
        {
            return _password.Equals(userPassword);
        }
        public override string ToString()
        {
            return "USernae "+Username+" Password : "+Password+" Role : "+Role;
        }
    }
}
