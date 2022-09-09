using EmployeeManagementDALibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDALibrary
{
    public interface IRepo
    {
        TblUser Add(TblUser user);
        TblUser Get(string username);
        ICollection<TblUser> GetAll();
        TblUser Update(TblUser user);
        TblUser Delete(string username);

    }
}
