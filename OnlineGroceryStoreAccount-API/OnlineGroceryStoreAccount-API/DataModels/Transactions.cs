using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreAccount_API.DataModels
{
    public class Transactions
    {
        [Key]
        public Guid transactionId { get; set; }
        public string trasnactionFor { get; set; }
        public DateTime date { get; set; }
        public int Debit { get; set; }
        public int Credit { get; set; }
        public int BalanceHistory{get;set;}
        public Guid CustomerId { get; set; }

    }
}
