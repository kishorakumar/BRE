using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Models
{
    public class ProductVideo: IProduct
    {
        public ProductTypes ProductType { get; }
        public string ProductName { get; set; }

        public string PaymentDone()
        {
            throw new NotImplementedException();
        }
    }
}
