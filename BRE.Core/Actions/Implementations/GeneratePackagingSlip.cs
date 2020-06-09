using BRE.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Actions
{
    public class GeneratePackagingSlip : IGeneratePackagingSlip
    {
        public string GeneratePackingSlip(IProduct product)
        {
            bool success = true;
            if (product.ProductType.Equals(ProductTypes.PhyscialProduct))
            {
                //Do some operation
                if (success)
                    return "Generated Packaging Slip";
                return "Error in Generating Packaging slip";
            }
            return string.Empty;
        }
    }
}
