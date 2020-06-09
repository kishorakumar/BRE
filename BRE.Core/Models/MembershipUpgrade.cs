using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Models
{
    public class MembershipUpgrade : IProduct
    {
        public ProductTypes ProductType { get { return ProductTypes.UpgradeMembership; } }
        public string ProductName { get; set; }

        public List<string> PaymentDone()
        {
            List<string> statues = new List<string>();
            statues.Add($"Upgraded {ProductName }'s membership");
            statues.Add($"Sent Email to {ProductName}");

            return statues;
        }
    }
}
