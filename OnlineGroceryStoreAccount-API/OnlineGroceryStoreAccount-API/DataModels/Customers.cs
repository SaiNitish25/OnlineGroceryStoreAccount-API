using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreAccount_API.DataModels
{
    public class Customers
    {
        [Key]
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public long Moblie { get; set; }
        public Transactions Transactions { get; set; }



    }
}
