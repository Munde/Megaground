using Megaground.SharedKenel.Models.Customers;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Megaground.SharedKenel.Domain.Services.Customers
{
    public interface ICustomerService
    {
        ValueTask<Customer> GetAsync(string id);
        ValueTask<IEnumerable<Customer>> GetAllAsync();
    }
}
