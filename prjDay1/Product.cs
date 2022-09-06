using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjDay1
{
    internal class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Pic { get; set; }

        public Product()
        {

        }

        public Product(int id, string? name, float? price, int? quantity, string? pic)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Pic = pic;
        }

        public virtual int GenerateID()
        {
            int id;
            Console.WriteLine("Please enter the product Id");
            //var result = Int32.TryParse(Console.ReadLine(), out id);
            //Console.WriteLine("Was the input a success?? "+result);
            while(Int32.TryParse(Console.ReadLine(), out id)==false)
                Console.WriteLine("Invalid entry for ID. Please try again");
            return id;
        }
        public void TakeProdutDetails()
        {
            
            Id = GenerateID();
            Console.WriteLine("Please enter the product name");
            Name = Console.ReadLine();
            float price;
            Console.WriteLine("Please enter the product Price");
            while (float.TryParse(Console.ReadLine(), out price) == false)
                Console.WriteLine("Invalid entry for Price. Please try again");
            Price = price;
            int quantity;
            Console.WriteLine("Please enter the product quantity");
            while (Int32.TryParse(Console.ReadLine(), out quantity) == false)
                Console.WriteLine("Invalid entry for quantity. Please try again");
            Quantity= quantity;
            Console.WriteLine("Please enter the product Pic path");
            Pic = Console.ReadLine();

        }
        public override string ToString()
        {
            return "Id : " + Id + "Name " + Name;
        }
        public override bool Equals(object? obj)
        {
            Product product = (Product)obj;
            return this.Id.Equals(product.Id);
        }
    }
}
