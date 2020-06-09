using BRE.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Actions
{
    public class GenerateDuplicatePackagingSlipForRoyalty : IGenerateDuplicatePackingSlipForRoyalty
    {
        public string GenerateDuplicatePackingSlipForRoyalty(IProduct product)
        {
            bool success = true;
            //Do some operation
            if (success)
                return "Generated Duplicate packing slip for the royalty department";
            return "Error in Generating Duplicate packing slip for the royalty department";
        }
    }
}
