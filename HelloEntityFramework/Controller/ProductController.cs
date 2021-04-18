using HelloEntityFramework.Models.Product;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HelloEntityFramework.Controller
{
    public static class ProductController
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
                Product product = new Product { ProductName = productName, Qty = qty, Price = price };

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

        public static void UpdateProductByName(string productName, int qty, decimal price)
        {
            using (ProductsEntities db = new ProductsEntities())
            {
                Product product = db.Products.FirstOrDefault(p => p.ProductName == productName);
                if (product != null)
                {
                    product.Qty = qty;
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
                var products = from p in db.Products
                             orderby p.ProductName
                             select p;
                foreach (var p in products)
                    Console.WriteLine($"Name: {p.ProductName}. Qty: {p.Qty}, Price: {p.Price}");
            }
        }
    }
}
