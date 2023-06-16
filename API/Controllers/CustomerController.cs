using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
         private readonly LawerDataContext _context;

        public CustomerController(LawerDataContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet("GetCustomers")]
        public async Task<ActionResult> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

         [HttpPost("AddCustomer")]
        public async Task<ActionResult> AddCustomer([FromBody] Customer customer)
        {
            var cust = await _context.Customers.SingleOrDefaultAsync(x => x.CustId == customer.CustId);

            if (await CustIDNoExist(customer.CustIdNumber)) return BadRequest("رقم الهوية موجود مسبقا");
            else
            {
                
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();

            }
            return Ok(true);
        }

        
        private async Task<bool> CustIDNoExist(string custIdNo)
        {
            return await _context.Customers.AnyAsync(x => x.CustIdNumber== custIdNo);
        }

          [HttpGet("GetCustomer/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
           var customer = await _context.Customers.FirstOrDefaultAsync(o => o.CustId == id);
            
            if(customer == null) return NotFound($"customer with Id = {id} not found");
             
            
            return Ok(customer);
        }

             [HttpPut("UpdateCustomer/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCustomer(int id ,[FromBody] Customer cust)
        {
           var customer = await _context.Customers.FindAsync(id);

            if(customer == null) return NotFound($"customer with Id = {id} not found");
          
             customer.CustName = cust.CustName;
             customer.CustIdNumber = cust.CustIdNumber;
             customer.CustEmail = cust.CustEmail;
             customer.CustCity = cust.CustCity;
             customer.CustAddress = cust.CustAddress;
             customer.CustMobile = cust.CustMobile;

            await _context.SaveChangesAsync();
            return Ok(customer);
        }


           [HttpDelete("DeleteCustomer/{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {

            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(o => o.CustId == id);
                if (customer == null)
                {
                    return NotFound($"Agency with Id = {id} not found");
                }
                _context.Remove(customer);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting Agency");
            }


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}