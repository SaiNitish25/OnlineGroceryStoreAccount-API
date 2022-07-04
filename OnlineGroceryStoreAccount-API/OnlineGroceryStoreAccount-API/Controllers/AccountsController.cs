using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStoreAccount_API.DataModels;
using OnlineGroceryStoreAccount_API.DomainModels;
using OnlineGroceryStoreAccount_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStoreAccount_API.Controllers
{
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IAccountRepository accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        //Get Calls

        [HttpGet]
        [Route("[Controller]/customers")]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var customers = await accountRepository.GetCustomersAsync();
                return Ok(customers);
        }

        [HttpGet]
        [Route("[Controller]/customer/{custId:Guid}")]
        public async Task<IActionResult> GetCustomerByIdAsync([FromRoute] Guid custId)
        {
            if(await accountRepository.IsCustomerExists(custId))
            {
                var customer=await accountRepository.GetCustomerByIdAsync(custId);
                return Ok(customer);

            }
            return NotFound();
        }

        [HttpGet]
        [Route("[Controller]/GetBalance/{custId:Guid}")]
        public async Task<IActionResult> GetBalanceAsync([FromRoute] Guid custId)
        {
            
                var balanceAmount = await accountRepository.GetCurrentBalance(custId);
                return Ok(balanceAmount);

            
            
        }

        [HttpGet]
        [Route("[controller]/GetTransactions/{custId:Guid}")]
        public async Task<IActionResult> GetTransactionsAsync([FromRoute] Guid custId)
        {
            var transactions = await accountRepository.GetTransactionsByCustIdAsync(custId);
            return Ok(transactions);
        }




        //Post Calls

        [HttpPost]
        [Route("[Controller]/AddCustomer")]
        public async Task<IActionResult> AddNewCustomer([FromBody] AddCustomer customer)
        {
            
            var newcustomer = new Customers();
            newcustomer.CustomerId= Guid.NewGuid();
            newcustomer.CustomerName = customer.CustomerName;
            newcustomer.Moblie = customer.Moblie;
            newcustomer.Address = customer.Address;
           var addedCustomer= await accountRepository.CreateCustomer(newcustomer);
            return Ok(addedCustomer);


        }

        [HttpPost]
        [Route("[Controller]/NewTransaction")]
        public async Task<IActionResult> AddNewTransaction([FromBody] AddTransaction addTransaction)
        {
            var transaction = new Transactions();
            transaction.transactionId = Guid.NewGuid();
            transaction.trasnactionFor = addTransaction.trasnactionFor;
            transaction.Debit = addTransaction.Debit;
            transaction.Credit = addTransaction.Credit;
            transaction.CustomerId = addTransaction.CustomerId;
            var newTrasaction = await accountRepository.AddNewTransactionAsync(transaction);
            return Ok(newTrasaction);

        }

        [HttpPut]
        [Route("[Controller]/EditCustomer/{custId:Guid}")]
        public async Task<IActionResult> EditCustomerAsync([FromRoute] Guid custId,[FromBody] AddCustomer editCustomer)
        {
            var customer = await accountRepository.EditCustomerAsync(custId, editCustomer);
            if (customer == null)
                return NotFound();
            
            return Ok(customer);


        }

    }
}
