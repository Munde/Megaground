using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megaground.SharedKenel.Models.Customers
{
    public class Customer : BaseEntity
    {
        [StringLength(50),Required]
        public string Firstname { get; set; }
    }
}
