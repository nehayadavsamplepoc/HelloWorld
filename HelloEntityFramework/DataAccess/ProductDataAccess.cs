using HelloEntityFramework.Models.Product;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HelloEntityFramework.DataAccess
{
    public static class ProductDataAccess
    {
        public static void AddProduct(Product product)
        {
            using (ProductsEntities db = new ProductsEntities())
            {
                db.Products.Add(product);
                db.SaveChanges();
                Console.WriteLine("New Product is added to database");
            }
        }

        public static void AddProduct(string productName, int qty, decimal price)
        {
            using (ProductsEntities db = new ProductsEntities())
            {
                Product product = new Product { ProductName = productName, Price = price };

                db.Products.Add(product);
                db.SaveChanges();
                Console.WriteLine("New Product is added to database");
            }
        }

        public static void RemoveProductByName(string productName)
        {
            using (ProductsEntities db = new ProductsEntities())
            {
                Product product = db.Products.FirstOrDefault(p => p.ProductName == productName);
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                    Console.WriteLine($"Product with name {productName} is removed from database");
                }
            }
        }

        public static void UpdateProductByName(string productName, decimal price)
        {
            using (ProductsEntities db = new ProductsEntities())
            {
                Product product = db.Products.FirstOrDefault(p => p.ProductName == productName);
                if (product != null)
                {
                    product.Price = price;
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    Console.WriteLine($"Product with name {productName} is updated");
                }
            }
        }

        public static void ViewProductWithSort()
        {
            using (ProductsEntities db = new ProductsEntities())
            {
                var products = db.Products.OrderBy(p => p.ProductName);
                foreach (var p in products)
                    Console.WriteLine($"Name: {p.ProductName}. Price: {p.Price}");
            }
        }

        public static void PrintProductInfo(string productName)
        {
            using (ProductsEntities db = new ProductsEntities())
            {
                if (db.Shipments.Where(s => s.Product.ProductName == productName).ToList().Count()==0)
                {
                    Console.WriteLine($"Product {productName} is not used in any orders");
                }
                else
                {
                    Console.WriteLine($"Product {productName} is used in orders:\n");

                    foreach (var shipment in db.Shipments.Where(s => s.Product.ProductName == productName))
                    {
                        Console.WriteLine($"Qty {shipment.Qty} in order {shipment.Order.Name}. " +
                            $"Wholesaler {shipment.Order.Wholesaler.Name}");
                    }
                }
            }
        }
    }
}
