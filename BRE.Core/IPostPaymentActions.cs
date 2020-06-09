using BRE.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core
{
    public interface IPostPaymentActions
    {
        public List<string> PerformPostPaymentActions(List<IProduct> products);
    }
}
