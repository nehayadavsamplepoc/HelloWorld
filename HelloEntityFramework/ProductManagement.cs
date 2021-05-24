using HelloEntityFramework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEntityFramework
{
    public static class ProductManagement
    {
        public static void AddProductToDb()
        {
            Console.WriteLine("Enter product name");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter qty");
            int qty = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter price");
            decimal price = decimal.Parse(Console.ReadLine());

            ProductDataAccess.AddProduct(productName, qty, price);
        }

        public static void RemoveProductFromDb()
        {
            Console.WriteLine("Enter product name");
            string productName = Console.ReadLine();

            ProductDataAccess.RemoveProductByName(productName);
        }

        public static void UpdateProductInDb()
        {
            Console.WriteLine("Enter product name to update");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter new price");
            decimal price = decimal.Parse(Console.ReadLine());

            ProductDataAccess.UpdateProductByName(productName, price);
        }

        public static void ViewProductsInDb()
        {
            ProductDataAccess.ViewProductWithSort();
        }

        public static void DisplayProductInfoInOrders()
        {
            Console.WriteLine("Enter product name");
            string productName = Console.ReadLine();

            ProductDataAccess.PrintProductInfo(productName);
        }
    }
}
