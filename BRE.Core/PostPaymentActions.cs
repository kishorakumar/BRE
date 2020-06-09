using BRE.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core
{
    public class PostPaymentActions : IPostPaymentActions
    {
        public List<string> PerformPostPaymentActions(List<IProduct> products)
        {
            List<string> statues = new List<string>();
            foreach(IProduct product in products)
            {

            }

            return statues;
        }
    }
}
