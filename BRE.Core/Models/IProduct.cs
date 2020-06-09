using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Models
{
    public interface IProduct
    {
        public ProductTypes ProductType { get; }
        public string ProductName { get; set; }

        List<string> PaymentDone();
    }
}
