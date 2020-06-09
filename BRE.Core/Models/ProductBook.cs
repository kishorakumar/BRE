using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Models
{
    public class ProductBook : IProduct
    {
        public string ProductType { get; set; }
        public string ProductName { get; set; }

        public string PaymentDone()
        {
            throw new NotImplementedException();
        }
    }
}
