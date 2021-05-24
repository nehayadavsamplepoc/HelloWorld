using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloEntityFramework;
using HelloEntityFramework.Models.Product;

namespace HelloEntityFramework.DataAccess
{
    public static class OrderDataAccess
    {
        public static void CreateOrder(string orderName, 
            string wholesalerName)
        {
            using (ProductsEntities db = new ProductsEntities())
            {
                Wholesaler wholesaler = db.Wholesalers.FirstOrDefault(wlsr => wlsr.Name == wholesalerName);

                if (wholesaler != null)
                {
                    Order order = new Order { Name = orderName, Wholesaler = wholesaler, WholesalerId = wholesaler.WholesalerId };
                    db.Orders.Add(order);

                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("New order is added to database");
                        OrderManagement.ActiverOrderName = orderName;
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine($"New order is not saved.\n {ex.Message}");
                    }                    
                }
                else
                {
                    Console.WriteLine($"Wholesaler {wholesalerName} is not exist");
                }
            }
        }

        public static void AddProductToOrder(string productName, int qty)
        {
            if (OrderManagement.ActiverOrderName.Equals(""))
                return;

            using (ProductsEntities db = new ProductsEntities())
            {
                Product product = db.Products.FirstOrDefault(p => p.ProductName == productName);
                Order activeOrder = db.Orders.FirstOrDefault(o => o.Name == OrderManagement.ActiverOrderName);

                if (product != null && activeOrder != null)
                {
                    Shipment shipment = new Shipment { Product = product, Qty = qty, Order = activeOrder, OrderId = activeOrder.OrderId };
                    db.Shipments.Add(shipment);
                    db.SaveChanges();
                    Console.WriteLine("New shipment is added to database");
                }
                else if (product != null)
                {
                    Console.WriteLine($"Product {productName} is absent database");
                }
                else
                {
                    Console.WriteLine($"There is no active order");
                }
            }
        }

        public static void DeleteActiveOrder()
        {
            if (OrderManagement.ActiverOrderName.Equals(""))
                return;

            using (ProductsEntities db = new ProductsEntities())
            {
                Order activeOrder = db.Orders.FirstOrDefault(o => o.Name == OrderManagement.ActiverOrderName);

                if (activeOrder != null)
                {
                    foreach (var shipment in db.Shipments.Where(s => s.OrderId == activeOrder.OrderId).ToList())
                    {
                        db.Shipments.Remove(shipment);
                        db.SaveChanges();
                    }

                    db.Orders.Remove(activeOrder);
                    db.SaveChanges();
                    Console.WriteLine($"Order with name {OrderManagement.ActiverOrderName} is removed from database");
                    OrderManagement.ActiverOrderName = "";
                }
            }
        }

        public static void PrintOrderInfo()
        {
            if (OrderManagement.ActiverOrderName.Equals(""))
                return;

            using (ProductsEntities db = new ProductsEntities())
            {
                Order activeOrder = db.Orders.FirstOrDefault(o => o.Name == OrderManagement.ActiverOrderName);

                if (activeOrder != null)
                {
                    var sum = 0m;
                    foreach (var shipment in db.Shipments.Where(s => s.OrderId == activeOrder.OrderId))
                    {
                        Console.WriteLine($"Product: {shipment.Product.ProductName}, Qty: {shipment.Qty}");
                        sum += (shipment.Product.Price * shipment.Qty);
                    }
                    Console.WriteLine($"Wholesaler: {activeOrder.Wholesaler.Name}");
                    Console.WriteLine($"Order value: {sum}");
                }
            }
        }

    }
}
