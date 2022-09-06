using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjDay1
{
    internal class Bill : IGenerateBill, IInitializeStore, IDisplayProducts
    {
         List<Product> products = new List<Product>();
        List<Product> cart = new List<Product>();
        public int BillNumber { get; set; }
        public string CustomerName { get; set; }
        public Bill()
        {

        }
        public Bill(int billNumber, string customerName)
        {
            BillNumber = billNumber;
            CustomerName = customerName;
        }
        public void TakeBillDetails()
        {
            int billnumber;
            Console.WriteLine("Please enter the Bill Number");
            while (Int32.TryParse(Console.ReadLine(), out billnumber) == false)
                Console.WriteLine("Invalid entry for Bill Number. Please try again");
            BillNumber = billnumber;
            Console.WriteLine("Please enter the Customer Name");
            CustomerName = Console.ReadLine();
            
        }
        public override string ToString()
        {
            string result =  "Bill number : "+BillNumber+"\nCustomer Name : "+CustomerName;
            result += "\nProductDetails\n";
            foreach (var item in cart)
            {
                result += item;
                result += "\n";
            }
            return result;
        }

        Product SearchProduct(int pid)
        {
            Product product = null;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == pid)
                {
                    product = products[i];
                    break;
                }
            }
            return product;
        }
        public void AddProduct(int pid, int qty = 1)
        {
            //search for product
            Product product = SearchProduct(pid);
            
            //create a product object using the product found with teh quantity given
            if(product == null)
            {
                Console.WriteLine("Unnaku shop panna arugadhe illa poi thola...");
                return;
            }
            Product myProduct = new Product();
            myProduct.Id = pid;
            myProduct.Name = product.Name;
            myProduct.Quantity = qty;
            myProduct.Price = product.Price;    
            myProduct.Pic = product.Pic;
            //modify the quantity of the actual product
            if((product.Quantity - qty)<0)
            {
                Console.WriteLine("I am sooo sorry we dont have tha many. Konjama order pannunga plzzzzz");
                return;
            }
            product.Quantity -= qty;

            //add the product to the cart
            cart.Add(myProduct);
            Console.WriteLine($"Your product is successfully added to cart. your car now has {cart.Count + 1} products");
        }

        public void DeleteProduct(int pid)
        {
            Product product = SearchProduct(pid);
            if(product==null)
            {
                Console.WriteLine("Apdi oru product ye illa");
                return;
            }
            cart.Remove(product);
            Console.WriteLine($"The product {product.Name} is removed form the cart");
                
        }

        public void PrintBill()
        {
            if (cart.Count == 0)
                Console.WriteLine("Onnume vangala edhuku bill???");
            else
                Console.WriteLine(this);
        }

        public void AddProducts()
        {
            string choice = "no";
            do
            {
                Product product = new Product();
                product.TakeProdutDetails();
                products.Add(product);
                Console.WriteLine("Do u want to buy more?? if not enter no");
                choice = Console.ReadLine().ToLower();

            } while (choice != "no");
        }

        public void PrintProducts()
        {
            foreach (var item in products)
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------");
            }
        }
    }
}
