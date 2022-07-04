using Microsoft.EntityFrameworkCore;
using OnlineGroceryStoreAccount_API.DataModels;
using OnlineGroceryStoreAccount_API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreAccount_API.Repositories
{
    public class AccountRepository : IAccountRepository

    {
        private readonly GroceryContext context;

        public AccountRepository(GroceryContext context)
        {
            this.context = context;
        }
        public async Task<Transactions> AddNewTransactionAsync(Transactions transactions)
        {
            var bh = 0;
            DateTime now= DateTime.UtcNow;
            transactions.date = now;
            //check customer has previous transactions
            if(await context.Transactions.AnyAsync(x => x.CustomerId == transactions.CustomerId)){
                var availabletransaction = await context.Transactions.Where(x => x.CustomerId == transactions.CustomerId).OrderByDescending(x => x.date).ToListAsync();
                bh = transactions.Credit - transactions.Debit;
                bh = availabletransaction[0].BalanceHistory + bh;
                transactions.BalanceHistory = bh;


            }
            //New Customer Transaction
            else
            {
                transactions.BalanceHistory = transactions.Credit - transactions.Debit; 
            }
            var newtransc = await context.Transactions.AddAsync(transactions);
            await context.SaveChangesAsync();
            return newtransc.Entity;
        }

        public async Task<Customers> CreateCustomer(Customers customer)
        {
            var addedcustomer=await  context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
            return addedcustomer.Entity;
        }

        public async Task<int> GetCurrentBalance(Guid customerId)
        {
            if (await context.Transactions.AnyAsync(x => x.CustomerId == customerId))
            {
                var availabletransaction = await context.Transactions.OrderByDescending(x => x.date).ToListAsync();

                return availabletransaction[0].BalanceHistory;


            }
            return 0;
        }

        public async Task<Customers> GetCustomerByIdAsync(Guid custId)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(x=>x.CustomerId==custId);
            return customer;
        }

        public async Task<List<Customers>> GetCustomersAsync()
        {
            var customers=await context.Customers.ToListAsync();
            return customers;

        }

        public async Task<List<Transactions>> GetTransactionsByCustIdAsync(Guid customerId)
        {
            var transactions = await context.Transactions.Where(x=>x.CustomerId==customerId).OrderByDescending(x => x.date).ToListAsync();
            return transactions;
        }

        public async Task<bool> IsCustomerExists(Guid custId)
        {
            if(await context.Customers.AnyAsync(x => x.CustomerId == custId))
            {
                return true;
            }
            return false;
        }

        public async Task<Customers> EditCustomerAsync(Guid id, AddCustomer editCustomer)
        {

            var customer = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
            if (customer != null) { 
                customer.CustomerName = editCustomer.CustomerName;
                customer.Address = editCustomer.Address;
                customer.Moblie = editCustomer.Moblie;
                await context.SaveChangesAsync();
                return customer;
            }
            return null;
        }
    }
}
