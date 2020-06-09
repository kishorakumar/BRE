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
            throw new NotImplementedException();
        }
    }
}
