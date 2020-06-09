using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Models
{
    public class ProductPhysical : IProduct
    {
        public ProductTypes ProductType { get { return ProductTypes.PhyscialProduct; } }
        public string ProductName { get ; set ; }

        public List<string> PaymentDone()
        {
            List<string> statues = new List<string>();
            statues.Add("Generated Packaging Slip");
            statues.Add("Generated Commision To Agent");

            return statues;
        }
    }
}
