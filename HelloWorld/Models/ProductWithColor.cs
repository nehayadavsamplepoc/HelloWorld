using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    public class ProductWithColor : Product
    {
        private static readonly Random RandGen = new Random(); // for generating random numbers
        public static readonly ProductColorComparer ByColorComparer = new ProductColorComparer();

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

        public class ProductColorComparer : IComparer<ProductWithColor>
        {
            public int Compare(ProductWithColor x, ProductWithColor y)
            {
                if (Object.ReferenceEquals(x, y))
                    return 0;
                else if (Object.ReferenceEquals(x, null))
                    return -1;
                else if (Object.ReferenceEquals(null, y))
                    return 1;

                return String.Compare(x.Color,y.Color);
            }
        }
    }
}
