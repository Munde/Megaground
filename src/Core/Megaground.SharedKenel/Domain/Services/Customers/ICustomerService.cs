using Megaground.SharedKenel.Models.Customers;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Megaground.SharedKenel.Domain.Services.Customers
{
    public interface ICustomerService
    {
        ValueTask<Customer> GetAsync(Guid id);
        ValueTask<IEnumerable<Customer>> GetAllAsync();
        ValueTask<Customer> CreateAsync(Customer customer);
    }
}
