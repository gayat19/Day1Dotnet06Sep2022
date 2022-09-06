using prjDay1;
using System;
using System.ComponentModel;
using System.Globalization;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bill bill = new Bill();
            MyStore store = new MyStore();
            store.CreateStore(bill);
            store.Purchase(bill);
        }
    }

 
}