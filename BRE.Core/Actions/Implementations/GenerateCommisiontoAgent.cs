using BRE.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Actions
{
    public class GenerateCommisiontoAgent : IGenerateCommisionToAgent
    {
        public string GeneratePackingCommisionToAgent(IProduct product)
        {
            bool success = true;
            if (product.ProductType.Equals(ProductTypes.PhyscialProduct) ||
                product.ProductType.Equals(ProductTypes.Book))
            {
                //Do some operation
                if (success)
                    return "Generated Commision To Agent";
                return "Error in Generating Commision To Agent";    
            }
            return string.Empty;
        }
    }
}
