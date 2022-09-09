using EmployeeManagementDALibrary;
using EmployeeManagementDALibrary.Models;
using System;

namespace prjUserManagementConsoleApp
{
    internal class Program
    {
        EmployeeADO obj = new EmployeeEF();
        IRepo repo = new UserRepo();
        void AddUser()
        {
            //TblUser user = new TblUser()
            //{
            //    Username = "mim",
            //    Password = "112",
            //    Role = "user"
            //};
            //if(obj.AddUser(user) !=null)
            //    Console.WriteLine("User created");
            //else
            //    Console.WriteLine("unakella oru user object");
            TblUser user = new TblUser()
            {
                Username = "Sim",
                Password = "112",
                Role = "admin"
            };
            
            if (repo.Add(user) != null)
                Console.WriteLine("User created");
            else
                Console.WriteLine("unakella oru user object");
        }
        void PrintUsers()
        {

            //var users = obj.GetUserFromDatabase();
            var users = repo.GetAll();
            foreach (var item in users)
            {
                Console.WriteLine(item.Username);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.AddUser();
            program.PrintUsers();

        }
    }
}
