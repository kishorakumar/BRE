using BRE.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Actions
{
    public interface IUpgradeMembership
    {
        string UpgradeMembership(IProduct product);
    }
}
