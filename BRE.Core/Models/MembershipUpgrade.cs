using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Models
{
    public class MembershipUpgrade : IProduct
    {
        public ProductTypes ProductType { get { return ProductTypes.UpgradeMembership; } }
        public string ProductName { get; set; }
    }
}
