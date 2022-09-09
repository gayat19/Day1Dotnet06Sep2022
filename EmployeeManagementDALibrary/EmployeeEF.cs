using EmployeeManagementDALibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDALibrary
{
    public class EmployeeEF : EmployeeADO
    {
        dbRecruitSep2022Context ctx = new dbRecruitSep2022Context();
        public override TblUser AddUser(TblUser user)
        {
            try
            {
                ctx.TblUsers.Add(user);
                ctx.SaveChanges();
                return user;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message + " "+DateTime.Now);

            }
            return null;
        }

        public override List<User> GetUserFromDatabase()
        {
           
            List<User> users = new List<User>();
            var myUSers = ctx.TblUsers;
            foreach (var item in myUSers)
            {
                User user = new User();
                user.Username = item.Username;
                user.Password = item.Password;
                user.Role = item.Role;
                users.Add(user);
            }
            return users;
        }
    }
}
