using System;
using System.Collections.Generic;
using System.Text;
using static HelloWorld.Models.ProductConstants;
using static HelloWorld.Sort;

namespace HelloWorld.Models
{
    public class ProductWithSizeComparer : IComparer<ProductWithSize>
    {
        private ProductField type;

        public ProductWithSizeComparer(ProductField type)
        {
            this.type = type;
        }

        public int Compare(ProductWithSize p1, ProductWithSize p2)
        {
            if (type.Equals(ProductField.Qty))
            {
                if (p1.Qty > p2.Qty)
                    return 1;
                else if (p1.Qty < p2.Qty)
                    return -1;
                else
                    return 0;
            }
            else if (type.Equals(ProductField.Price))
            {
                if (p1.Price > p2.Price)
                    return 1;
                else if (p1.Price < p2.Price)
                    return -1;
                else
                    return 0;
            }
            else if (type.Equals(ProductField.Size))
            {
                if (p1.Size > p2.Size)
                    return 1;
                else if (p1.Size < p2.Size)
                    return -1;
                else
                    return 0;
            }
            else
                throw new Exception("Please choose Qty, Price or Size product field for sort");
        }
    }
}
