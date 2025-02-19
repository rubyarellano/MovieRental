using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.Models;

namespace MovieRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MovieRentalDbContext _context;

        public CustomerController(MovieRentalDbContext context)
        {
            _context = context;
        }
    
    
        [HttpPost]
        public async Task<ActionResult<Customers>> PostCustomer(Customers customers)
        {
            _context.Customer.Add(customers);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { Id = customers. CustomerId}, customers);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomer()
        {
            if (_context.Customer == null)
            {

                return NotFound();
            }
            return await _context.Customer.ToListAsync();
        }


        [HttpPut]
        public async Task<ActionResult> PutCustomer(int CustomerId, Customers customers)
        {
            if (CustomerId != customers. CustomerId)
            {
                return BadRequest();
            }
            _context.Entry(customers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersAvailable(CustomerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();

        }
        private bool CustomersAvailable(int CustomerId)
        {
            return (_context.Customer?.Any(x => x.CustomerId == CustomerId)).GetValueOrDefault();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomer(int id)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            var Customer = await _context.Customer.FindAsync(id);
            if (Customer == null)
            {
                return NotFound();

            }
            return Customer;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            var customers= await _context.Customer.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            _context.Customer.Remove(customers);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}


