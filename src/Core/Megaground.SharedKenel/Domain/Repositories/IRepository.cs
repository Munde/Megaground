using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megaground.SharedKenel.Domain.Repositories
{
    public interface IRepository <T> where T:class
    {
        // Create operation
        ValueTask<T> AddAsync(T t);
        ValueTask<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entinties);
        //
    }
}
