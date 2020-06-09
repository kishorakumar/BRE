using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Models
{
    public class ProductBook : IProduct
    {
        public ProductTypes ProductType { get; }
        public string ProductName { get; set; }

        public List<string> PaymentDone()
        {
            List<string> statues = new List<string>();
            statues.Add("Generated Duplicate packing slip for the royalty department");
            statues.Add("Generated Commision To Agent");

            return statues;
        }
    }
}
