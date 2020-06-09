using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Actions
{
    public interface ISendEmail
    {
        string SendEmail(string from, string to, string body);
    }
}
