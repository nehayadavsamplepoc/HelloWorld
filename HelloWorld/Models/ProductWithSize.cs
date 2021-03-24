using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    public class ProductWithSize : Product
    {
        private static readonly Random RandGen = new Random(); // for generating random numbers

        public int Size;

        public ProductWithSize(int qty) : base(qty)
        {
            Size = RandGen.Next(1000);
        }
    }
}
