using System;
using System.Collections.Generic;
using System.Text;
using static HelloWorld.Models.ProductConstants;
using static HelloWorld.Sort;

namespace HelloWorld.Models
{
    public class ProductComparer : IComparer<Product>
    {
        private ProductField type;

        public ProductComparer(ProductField type)
        {
            this.type = type;
        }

        public int Compare(Product p1, Product p2)
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
            else
                throw new Exception("Please choose Qty or Price product field for sort");
        }
    }
}
