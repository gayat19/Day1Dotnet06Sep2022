using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjDay1
{
    internal interface IGenerateBill
    {
        void AddProduct(int pid, int qty=1);
        void DeleteProduct(int pid);
        void PrintBill();
    }
}
