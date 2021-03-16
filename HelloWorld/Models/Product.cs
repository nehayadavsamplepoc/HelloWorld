using System;

namespace HelloWorld.Models
{
    public class Product
    {
        private static readonly Random RandGen = new Random(); // for generating random numbers

        public int Qty;
        public decimal Price;

        public Product(int qty)
        {
            Qty = qty;
            Price = decimal.Parse($"{RandGen.Next(1000)},{RandGen.Next(100)}");
        }
    }
}