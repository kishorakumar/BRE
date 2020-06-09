using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Actions.Implementations
{
    public class EmailSender : ISendEmail
    {
        public string ActivateMembership(string from, string to, string body)
        {
            bool success = true;
            //Do some operation
            if (success)
                return $"Sent Email to {to}";
            return $"Error in Sending Email to {to}";
        }
    }
}
