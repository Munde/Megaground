using Megaground.SharedKenel.Domain.Services.Customers;
using Megaground.SharedKenel.Models.Customers;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Megaground.Services.Customers
{
    internal class CustomerService : ICustomerService
    {
        public ValueTask<IEnumerable<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Customer> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
