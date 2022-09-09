using EmployeeManagementDALibrary.Models;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementDALibrary
{
    public abstract class EmployeeADO
    {
        //Create connection
        SqlConnection conn;
        public EmployeeADO()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-1C1EU5R\SQLSERVER2019G3;Integrated security=true;Initial Catalog=dbRecruitSep2022");
        }
        public virtual List<User> GetUserFromDatabase()
        {
            List<User> users = new List<User>();    
            //create command
            SqlDataAdapter daUser = new SqlDataAdapter("Select * from tblUsers",conn);
            DataSet ds = new DataSet();
            //execute command - connect -fetch data-> disconnect
            daUser.Fill(ds);
            //store data
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                User user = new User();
                user.Username = item[0].ToString();
                user.Password = item[1].ToString();
                user.Role = item[2].ToString();
                users.Add(user);
            }
            //return data
            return users;
        }

        public abstract TblUser AddUser(TblUser user);
        

    }
}