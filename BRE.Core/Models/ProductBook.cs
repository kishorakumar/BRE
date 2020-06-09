using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Models
{
    public class ProductBook : IProduct
    {
        public ProductTypes ProductType { get { return ProductTypes.Book; } }
        public string ProductName { get; set; }
    }
}
