using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreAccount_API.DataModels
{
    public class GroceryContext:DbContext

    {
        public GroceryContext(DbContextOptions<GroceryContext> options):base(options)
        {

        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
    }
}
