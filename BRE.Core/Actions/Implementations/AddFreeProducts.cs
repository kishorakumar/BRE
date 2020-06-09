using BRE.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Actions.Implementations
{
    public class AddFreeProducts : IAddEligibleFreeProducts
    {
        public string AddEligibleFreeProducts(IProduct product)
        {
            bool success = true;
            string status = string.Empty;
            //Do some operation
            if (product.ProductName.Equals("Learning to Ski"))
            {
                status = "Added 'First Aid' for free (as per court decision 1997) ";
            }
            if (success)
                return status;
            return "Error in Adding free Product";

        }
    }
}
