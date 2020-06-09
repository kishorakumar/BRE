using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core.Models
{
    public class ProductVideo: IProduct
    {
        public ProductTypes ProductType { get; }
        public string ProductName { get; set; }

        public List<string> PaymentDone()
        {
            List<string> statues = new List<string>();
            if(ProductName.Equals("Learning to Ski"))
            {
                statues.Add("Added 'First Aid' for free (as per court decision 1997) ");
            }

            return statues;
        }
    }
}
