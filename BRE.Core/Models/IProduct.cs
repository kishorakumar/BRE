using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Models
{
    public interface IProduct
    {
        public string ProductType { get; set; }
        public string ProductName { get; set; }

        string PaymentDone();
    }
}
