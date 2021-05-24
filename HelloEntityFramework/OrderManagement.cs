using HelloEntityFramework.DataAccess;
using HelloEntityFramework.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEntityFramework
{
    public static class OrderManagement
    {
        public static string ActiverOrderName = "";

        public static void CreateOrder()
        {
            Console.WriteLine("Enter order name");
            string orderName = Console.ReadLine();

            Console.WriteLine("Enter wholesaler name");
            string wholesalerName = Console.ReadLine();

            OrderDataAccess.CreateOrder(orderName, wholesalerName);
        }

        public static void CreateOrder(string orderName)
        {
            Console.WriteLine("Enter wholesaler name");
            string wholesalerName = Console.ReadLine();

            OrderDataAccess.CreateOrder(orderName, wholesalerName);
        }

        public static void DeleteOrder()
        {
            OrderDataAccess.DeleteActiveOrder();
        }

        public static void MakeOrderActive()
        {
            Console.WriteLine("Enter order name");
            string orderName = Console.ReadLine();

            using (ProductsEntities db = new ProductsEntities())
            {
                Order activeOrder = db.Orders.FirstOrDefault(o => o.Name == orderName);

                if (activeOrder != null)
                {
                    ActiverOrderName = orderName;
                    Console.WriteLine($"Order name {ActiverOrderName} is active");
                }
                else
                {
                    Console.WriteLine($"Order {orderName} is absent. Do you want to create new order with name {orderName}? (y/n)");
                    string answer = Console.ReadLine();
                    if (answer.Equals("y"))
                        CreateOrder(orderName);
                }
            }
        }

        public static void AddProductToOrder()
        {
            Console.WriteLine("Enter product name");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter qty");
            if (!(Int32.TryParse(Console.ReadLine(), out int qty)))
            {
                Console.WriteLine("Incorrect qty format");
                return;
            }

            OrderDataAccess.AddProductToOrder(productName, qty);
        }

        public static void DisplayOrderInfo()
        {
            OrderDataAccess.PrintOrderInfo();
        }

    }
}
