using Megaground.SharedKenel.Domain.Repositories.Customers;
using Megaground.SharedKenel.Domain.Services.Customers;
using Megaground.SharedKenel.Models.Customers;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Megaground.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepostory;

        public CustomerService(ICustomerRepository customerRepostory)
        {
            _customerRepostory = customerRepostory;
        }

        public async ValueTask<Customer> CreateAsync(Customer customer)
        {
            try
            {
               await _customerRepostory.CreateAsync(customer);
               await _customerRepostory.SaveChangesAsync();
               return customer;
            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }
        }

        public async ValueTask<IEnumerable<Customer>> GetAllAsync()
        {
            try
            {
                // unaweza kutumia unit of work kupunguza hizi mbilinge
                return await _customerRepostory.GetAllAsync();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        public async ValueTask<Customer> GetAsync(Guid id)
        {
            try
            {
                return await _customerRepostory.GetAsync(id);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}
