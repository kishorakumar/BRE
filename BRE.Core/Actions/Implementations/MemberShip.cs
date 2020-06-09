using BRE.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Actions
{
    public class Membership : IActivateMembership, IUpgradeMembership
    {
        public string ActivateMembership(IProduct product)
        {
            bool success = true;
            //Do some operation
            if (success)
                return $"Activated { product.ProductName }'s membership";
            return $"Error Activating { product.ProductName }'s membership";
        }

        public string UpgradeMembership(IProduct product)
        {
            bool success = true;
            //Do some operation
            if (success)
                return $"Upgraded { product.ProductName }'s membership";
            return $"Error Upgrading { product.ProductName }'s membership";
        }
    }
}
