using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjDay1
{
    internal class MyStore
    {
        public void CreateStore(IInitializeStore store)
        {
            store.AddProducts();
        }
        public void ShowProducts(IDisplayProducts products)
        {
            products.PrintProducts();
        }
        void PrintMenu()
        {
            Console.WriteLine("1. Print Product list");
            Console.WriteLine("2. Add a product to cart");
            Console.WriteLine("3. Remove a product from cart");
            Console.WriteLine("4. Complete purchase");
            Console.WriteLine("0. To exit");
        }
        public void Purchase(IGenerateBill bill)
        {
            int choice = 0;
            do
            {
                PrintMenu();
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye......");
                        break;
                    case 1:
                        ShowProducts((IDisplayProducts)bill);
                        break;
                    case 2:
                        Console.WriteLine("Please enter teh product ID");
                        int pid = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the quantity");
                        int qty = Int32.Parse(Console.ReadLine());
                        bill.AddProduct(pid, qty);
                        break;
                    case 3:
                        Console.WriteLine("Please enter teh product ID");
                        int id = Int32.Parse(Console.ReadLine());
                        bill.DeleteProduct(id);
                        break;
                    case 4:
                        bill.PrintBill();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again");
                        break;
                }

            } while (choice!=0);
        }
    }
}
