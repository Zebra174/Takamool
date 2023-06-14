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
    public class UserController : Controller
    {        private readonly LawerDataContext _context;

        public UserController(LawerDataContext dbContext)
        {
           _context = dbContext;
        }
        
         [HttpGet("GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await (from a in _context.IsuuesLokupTables
                   join b in _context.Users
            on a.LokupId equals b.UserType
                   // join k in _context.IsuuesLokupTables on  a.IsuueType equals k.LokupId
                   where a.LokupType == 5
                   select new { a.LokupValue,b.UserId,b.Name,b.Username,b.DateOfBirth }).ToListAsync();
            return Ok(users);
        }
        
               [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser([FromBody] User lawer)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserId == lawer.UserId);

            if (await EmailExist(lawer.Username.ToString())) return BadRequest("البريد الاكتروني موجود مسبقا");
            else
            {
                await _context.Users.AddAsync(lawer);
                await _context.SaveChangesAsync();

            }
            return Ok(true);
        }

            private async Task<bool> EmailExist(string? title)
        {
            return await _context.Users.AnyAsync(x => x.Username == title);
        }
        
          [HttpGet("GetUserRoles")]
        public async Task<ActionResult> GetUserRoles()
        {
            var usersRoles = await _context.IsuuesLokupTables.Where(x=>x.LokupType==5).ToListAsync();
            return Ok(usersRoles);
        }

          [HttpDelete("DeleteUser/{id}")]
         public async Task<ActionResult> DeleteUser(int id)
        {

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(o => o.UserId == id);
                if (user == null)
                {
                    return NotFound($"user with Id = {id} not found");
                }
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting User");
            }


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}