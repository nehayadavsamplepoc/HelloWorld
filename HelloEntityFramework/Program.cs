using System;
using HelloEntityFramework.Models;
using HelloEntityFramework.DataAccess;

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
                Console.WriteLine("Enter: 5 - display product info, 6 - create order, 7 - delete order");
                Console.WriteLine("Enter: 8 - add product to order, 9 - change active order, 10 - display order info");
                Console.WriteLine("Enter: 11 - add wholesaler");
                Console.WriteLine("Enter 0 to exit\n");
                if (!(OrderManagement.ActiverOrderName.Equals("")))
                    Console.WriteLine($"Current active order {OrderManagement.ActiverOrderName}\n");
                else
                    Console.WriteLine($"There is no active order\n");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ProductManagement.AddProductToDb();
                        break;
                    case "2":
                        ProductManagement.RemoveProductFromDb();
                        break;
                    case "3":
                        ProductManagement.UpdateProductInDb();
                        break;
                    case "4":
                        ProductManagement.ViewProductsInDb();
                        break;
                    case "5":
                        ProductManagement.DisplayProductInfoInOrders();
                        break;
                    case "6":
                        OrderManagement.CreateOrder();
                        break;
                    case "7":
                        OrderManagement.DeleteOrder();
                        break;
                    case "8":
                        OrderManagement.AddProductToOrder();
                        break;
                    case "9":
                        OrderManagement.MakeOrderActive();
                        break;
                    case "10":
                        OrderManagement.DisplayOrderInfo();
                        break;
                    case "11":
                        WholesalerManagement.AddWholesaler();
                        break;
                    case "0":
                    default:
                        exit = true;
                        break;
                }
                Console.WriteLine("Click Enter to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }        
    }
}
