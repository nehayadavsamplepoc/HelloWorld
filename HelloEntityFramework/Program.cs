using System;
using HelloEntityFramework.Models;
using HelloEntityFramework.Controller;

namespace HelloEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Enter: 1 - add product, 2 - remove by name, 3 - update by name, 4 - view all with sort");
                Console.WriteLine("Enter 0 to exit");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        AddProductToDb();
                        break;
                    case "2":
                        RemoveProductFromDb();
                        break;
                    case "3":
                        UpdateProductInDb();
                        break;
                    case "4":
                        ViewProductsInDb();
                        break;
                    case "0":
                    default:
                        exit = true;
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        public static void AddProductToDb()
        {
            Console.WriteLine("Enter product name");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter qty");
            int qty = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter price");
            decimal price = decimal.Parse(Console.ReadLine());

            ProductController.AddProduct(productName, qty, price);
        }

        public static void RemoveProductFromDb()
        {
            Console.WriteLine("Enter product name");
            string productName = Console.ReadLine();

            ProductController.RemoveProductByName(productName);
        }

        public static void UpdateProductInDb()
        {
            Console.WriteLine("Enter product name to update");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter new qty");
            int qty = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new price");
            decimal price = decimal.Parse(Console.ReadLine());

            ProductController.UpdateProductByName(productName, qty, price);
        }

        public static void ViewProductsInDb()
        {
            ProductController.ViewProductWithSort();
        }
    }
}
