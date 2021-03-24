using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    public class ProductWithColor : Product
    {
        private static readonly Random RandGen = new Random(); // for generating random numbers

        public string Color;

        public ProductWithColor(int qty) : base(qty)
        {
            Color = GenerateRandomColor();
        }

        private string GenerateRandomColor()
        {
            var color = new string[] { "black", "white", "red", "green", "yellow",
                "blue", "pink", "gray", "brown", "orange", "purple" };
            return color[RandGen.Next(color.Length)];
        }
    }
}
