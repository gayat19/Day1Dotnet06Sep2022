using EmployeeManagementDALibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDALibrary
{
    public class UserRepo : IRepo
    {
        dbRecruitSep2022Context ctx = new dbRecruitSep2022Context();
        public TblUser Add(TblUser user)
        {
            try
            {
                ctx.TblUsers.Add(user);
                ctx.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + " " + DateTime.Now);

            }
            return null;
        }

        public TblUser Delete(string username)
        {
            try
            {
                //select * from tblUSer where username = username
                TblUser myUser = Get(username);
                if (myUser != null)
                {
                    ctx.TblUsers.Remove(myUser);
                    ctx.SaveChanges();
                }
                return myUser;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + " " + DateTime.Now);
            }
            return null;
        }

        public TblUser Get(string username)
        {
            try
            {
                //select * from tblUSer where username = username
                TblUser user = ctx.TblUsers.FirstOrDefault(user => user.Username == username);
                return user;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + " " + DateTime.Now);
            }
            return null;
        }

        public ICollection<TblUser> GetAll()
        {
            return ctx.TblUsers.ToList();
        }

        public TblUser Update(TblUser user)
        {
            try
            {
                //select * from tblUSer where username = username
                TblUser myUser = Get(user.Username);
                if(myUser != null)
                {
                    myUser.Password = user.Password;
                    myUser.Role = user.Role;
                    ctx.SaveChanges();
                }

                return myUser;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + " " + DateTime.Now);
            }
            return null;
        }
    }
}
