using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Models
{
    public class MembershipNew : IProduct
    {
        public ProductTypes ProductType { get;}
        public string ProductName { get; set; }

        public List<string> PaymentDone()
        {
            List<string> statues = new List<string>();
            statues.Add($"Activated {ProductName }'s membership");
            statues.Add($"Sent Email to {ProductName}");

            return statues;
        }
    }
}
