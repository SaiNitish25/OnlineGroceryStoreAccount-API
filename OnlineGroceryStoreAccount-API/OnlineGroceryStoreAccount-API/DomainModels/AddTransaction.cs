using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreAccount_API.DomainModels
{
    public class AddTransaction
    {
        public string trasnactionFor { get; set; }
        
        public int Debit { get; set; }
        public int Credit { get; set; }
        public Guid CustomerId { get; set; }
    }
}
