using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreAccount_API.DomainModels
{
    public class AddCustomer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public long  Moblie { get; set; }
    }
}
