using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreAccount_API.DomainModels
{
    public class UpdateCustomer
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public int Moblie { get; set; }
    }
}
