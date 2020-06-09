using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Models
{
    public class MembershipNew : IProduct
    {
        public ProductTypes ProductType { get { return ProductTypes.NewMembership; } }
        public string ProductName { get; set; }
    }
}
