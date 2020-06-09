using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Actions.Interfaces
{
    public interface ISendEmail
    {
        string ActivateMembership(string from, string to, string body);
    }
}
