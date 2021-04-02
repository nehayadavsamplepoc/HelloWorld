using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    public class ProductWithSize : Product
    {
        private static readonly Random RandGen = new Random(); // for generating random numbers
        public static readonly ProductSizeComparer BySizeComparer = new ProductSizeComparer();

        public int Size;

        public ProductWithSize(int qty) : base(qty)
        {
            Size = RandGen.Next(1000);
        }

        public class ProductSizeComparer : IComparer<ProductWithSize>
        {
            public int Compare(ProductWithSize x, ProductWithSize y)
            {
                if (Object.ReferenceEquals(x, y))
                    return 0;
                else if (Object.ReferenceEquals(x, null))
                    return -1;
                else if (Object.ReferenceEquals(null, y))
                    return 1;

                return (x.Size).CompareTo(y.Size);
            }
        }
    }
}
