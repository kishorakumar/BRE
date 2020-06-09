using BRE.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Actions.Interfaces
{
    public interface IGeneratePackagingSlip
    {
        string GeneratePackingSlip(IProduct product);
    }
}
