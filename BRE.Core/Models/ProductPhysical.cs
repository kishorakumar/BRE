using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Models
{
    public class ProductPhysical : IProduct
    {
        public ProductTypes ProductType { get { return ProductTypes.PhyscialProduct; } }
        public string ProductName { get ; set ; }

        public string PaymentDone()
        {
            return "Generated Packaging Slip";
        }
    }
}
