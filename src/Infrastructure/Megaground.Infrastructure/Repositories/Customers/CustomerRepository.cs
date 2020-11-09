using Megaground.Infrastructure.Data;
using Megaground.SharedKenel.Domain.Repositories.Customers;
using Megaground.SharedKenel.Models.Customers;

namespace Megaground.Infrastructure.Repositories.Customers
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MegagroundContext context) : base(context)
        {
        }
    }
}
