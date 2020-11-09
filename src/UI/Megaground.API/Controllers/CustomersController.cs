using Megaground.SharedKenel.Domain.Services.Customers;
using Megaground.SharedKenel.Models.Customers;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Megaground.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get(Guid id)
        {
            var customer = await _customerService.GetAsync(id);
            return Ok(customer);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async ValueTask<IActionResult> Post([FromBody]Customer customer)
        {
            //get user id from here
            await _customerService.CreateAsync(customer);
            return CreatedAtAction("Get", new { customer.Id},customer);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
