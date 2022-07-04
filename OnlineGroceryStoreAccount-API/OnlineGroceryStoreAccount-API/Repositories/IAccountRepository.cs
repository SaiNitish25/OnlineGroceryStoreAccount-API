using OnlineGroceryStoreAccount_API.DataModels;
using OnlineGroceryStoreAccount_API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreAccount_API.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Customers>> GetCustomersAsync();
        Task<Customers> GetCustomerByIdAsync(Guid custId);
        Task<Customers> CreateCustomer(Customers customer);
        Task<List<Transactions>> GetTransactionsByCustIdAsync(Guid customerId);
        Task<Transactions> AddNewTransactionAsync(Transactions transactions);
        Task<int> GetCurrentBalance(Guid customerId);

        Task<bool> IsCustomerExists(Guid custId);

        Task<Customers> EditCustomerAsync(Guid Id, AddCustomer editcustomer);



    }
}
