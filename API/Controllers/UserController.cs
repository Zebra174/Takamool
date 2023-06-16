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
        
          [HttpGet("GetUser/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUser(int id)
        {
           var user = await _context.Users.FirstOrDefaultAsync(o => o.UserId == id);
            
            if(user == null) return NotFound($"user with Id = {id} not found");
             
            
            return Ok(user);
        }

             [HttpPut("UpdateUser/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUser(int id ,[FromBody] User u)
        {
           var user = await _context.Users.FindAsync(id);

            if(user == null) return NotFound($"user with Id = {id} not found");
          
             user.UserType = u.UserType;
             user.Name = u.Name;
             user.DateOfBirth = u.DateOfBirth;
             user.Username = u.Username;
             user.Pass = u.Pass;
            

            await _context.SaveChangesAsync();
            return Ok(user);
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


           [HttpGet("GetIssueTypes")]
        public async Task<ActionResult> GetIssueTypes()
        {
            var usersRoles = await _context.IsuuesLokupTables.Where(x=>x.LokupType==1).ToListAsync();
            return Ok(usersRoles);
        }

        [HttpPost("AddIssueType")]
        public async Task<ActionResult> AddIssueType([FromBody] IsuuesLokupTable IT)
        {
            var issueType = await _context.IsuuesLokupTables.SingleOrDefaultAsync(x => x.LokupId == IT.LokupId);

            if (await TypesExist(IT.LokupValue.ToString())) return BadRequest("نوع القضية موجود مسبقا");
            else
            {
                IT.LokupType=1;
                await _context.IsuuesLokupTables.AddAsync(IT);
                await _context.SaveChangesAsync();

            }
            return Ok(true);
        }

               private async Task<bool> TypesExist(string? title)
        {
            return await _context.IsuuesLokupTables.AnyAsync(x => x.LokupValue == title);
        }

       
        
          [HttpGet("GetIssueType/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetIssueType(int id)
        {
           var issueType = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==1);
            
            if(issueType == null) return NotFound($"issueType with Id = {id} not found");
             
            
            return Ok(issueType);
        }

             [HttpPut("UpdateIssueType/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateIssueType(int id ,[FromBody] IsuuesLokupTable it)
        {
           var issueType = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==1);

            if(issueType == null) return NotFound($"issueType with Id = {id} not found");
          
             issueType.LokupType=1;
             issueType.LokupId=it.LokupId;
             issueType.LokupValue=it.LokupValue;

            await _context.SaveChangesAsync();
            return Ok(issueType);
        }


          [HttpDelete("DeleteIssueType/{id}")]
         public async Task<ActionResult> DeleteIssueType(int id)
        {

            try
            {
                var issueType = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==1);
                if (issueType == null)
                {
                    return NotFound($"issueType with Id = {id} not found");
                }
                _context.Remove(issueType);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting User");
            }


        }

        
           [HttpGet("GetIssueStatus")]
        public async Task<ActionResult> GetIssueStatus()
        {
            var usersRoles = await _context.IsuuesLokupTables.Where(x=>x.LokupType==2).ToListAsync();
            return Ok(usersRoles);
        }


        
        [HttpPost("AddIssueStatus")]
        public async Task<ActionResult> AddIssueStatus([FromBody] IsuuesLokupTable IT)
        {
            var issueStatus = await _context.IsuuesLokupTables.SingleOrDefaultAsync(x => x.LokupId == IT.LokupId);

            if (await TypesExist(IT.LokupValue.ToString())) return BadRequest("حالة القضية موجود مسبقا");
            else
            {
                IT.LokupType=2;
                await _context.IsuuesLokupTables.AddAsync(IT);
                await _context.SaveChangesAsync();

            }
            return Ok(true);
        }

      
       
        
          [HttpGet("GetIssueStatus/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetIssueStatus(int id)
        {
           var issueStatus = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==2);
            
            if(issueStatus == null) return NotFound($"issueStatus with Id = {id} not found");
             
            
            return Ok(issueStatus);
        }

             [HttpPut("UpdateIssueStatus/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateIssueStatus(int id ,[FromBody] IsuuesLokupTable it)
        {
           var issueStatus = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==2);

            if(issueStatus == null) return NotFound($"issueStatus with Id = {id} not found");
          
             issueStatus.LokupType=2;
             issueStatus.LokupId=it.LokupId;
             issueStatus.LokupValue=it.LokupValue;

            await _context.SaveChangesAsync();
            return Ok(issueStatus);
        }


          [HttpDelete("DeleteIssueStatus/{id}")]
         public async Task<ActionResult> DeleteIssueStatus(int id)
        {

            try
            {
                var issueStatus = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==2);
                if (issueStatus == null)
                {
                    return NotFound($"issueStatus with Id = {id} not found");
                }
                _context.Remove(issueStatus);
                await _context.SaveChangesAsync();
                return Ok(issueStatus);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting User");
            }


        }

          [HttpGet("GetContractType")]
        public async Task<ActionResult> GetContractType()
        {
            var usersRoles = await _context.IsuuesLokupTables.Where(x=>x.LokupType==3).ToListAsync();
            return Ok(usersRoles);
        }

           [HttpPost("AddContractType")]
        public async Task<ActionResult> AddContractType([FromBody] IsuuesLokupTable IT)
        {
            var contractType = await _context.IsuuesLokupTables.SingleOrDefaultAsync(x => x.LokupId == IT.LokupId);

            if (await TypesExist(IT.LokupValue.ToString())) return BadRequest("نوع العقد موجود مسبقا");
            else
            {
                IT.LokupType=3;
                await _context.IsuuesLokupTables.AddAsync(IT);
                await _context.SaveChangesAsync();

            }
            return Ok(true);
        }

      
       
        
          [HttpGet("GetContractType/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetContractType(int id)
        {
           var contractType = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==3);
            
            if(contractType == null) return NotFound($"contractType with Id = {id} not found");
             
            
            return Ok(contractType);
        }

             [HttpPut("UpdateContractType/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateContractType(int id ,[FromBody] IsuuesLokupTable it)
        {
           var contractType = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==3);

            if(contractType == null) return NotFound($"contractType with Id = {id} not found");
          
             contractType.LokupType=3;
             contractType.LokupId=it.LokupId;
             contractType.LokupValue=it.LokupValue;

            await _context.SaveChangesAsync();
            return Ok(contractType);
        }


          [HttpDelete("DeleteContractType/{id}")]
         public async Task<ActionResult> DeleteContractType(int id)
        {

            try
            {
                var contractType = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==3);
                if (contractType == null)
                {
                    return NotFound($"contractType with Id = {id} not found");
                }
                _context.Remove(contractType);
                await _context.SaveChangesAsync();
                return Ok(contractType);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting User");
            }

        }
        
          [HttpGet("GetServiceType")]
        public async Task<ActionResult> GetServiceType()
        {
            var usersRoles = await _context.IsuuesLokupTables.Where(x=>x.LokupType==4).ToListAsync();
            return Ok(usersRoles);
        }

          [HttpPost("AddServiceType")]
        public async Task<ActionResult> AddServiceType([FromBody] IsuuesLokupTable IT)
        {
            var serviceType = await _context.IsuuesLokupTables.SingleOrDefaultAsync(x => x.LokupId == IT.LokupId);

            if (await TypesExist(IT.LokupValue.ToString())) return BadRequest("نوع الخدمة موجود مسبقا");
            else
            {
                IT.LokupType=4;
                await _context.IsuuesLokupTables.AddAsync(IT);
                await _context.SaveChangesAsync();

            }
            return Ok(true);
        }

      
       
        
          [HttpGet("GetServiceType/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetServiceType(int id)
        {
           var serviceType = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==4);
            
            if(serviceType == null) return NotFound($"serviceType with Id = {id} not found");
             
            
            return Ok(serviceType);
        }

             [HttpPut("UpdateServiceType/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateServiceType(int id ,[FromBody] IsuuesLokupTable it)
        {
           var serviceType = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==4);

            if(serviceType == null) return NotFound($"serviceType with Id = {id} not found");
          
             serviceType.LokupType=4;
             serviceType.LokupId=it.LokupId;
             serviceType.LokupValue=it.LokupValue;

            await _context.SaveChangesAsync();
            return Ok(serviceType);
        }


          [HttpDelete("DeleteServiceType/{id}")]
         public async Task<ActionResult> DeleteServiceType(int id)
        {

            try
            {
                var serviceType = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==4);
                if (serviceType == null)
                {
                    return NotFound($"serviceType with Id = {id} not found");
                }
                _context.Remove(serviceType);
                await _context.SaveChangesAsync();
                return Ok(serviceType);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting User");
            }

        }

           [HttpGet("GetUserRoles")]
        public async Task<ActionResult> GetUserRoles()
        {
            var usersRoles = await _context.IsuuesLokupTables.Where(x=>x.LokupType==5).ToListAsync();
            return Ok(usersRoles);
        }

          [HttpPost("AddUserRoles")]
        public async Task<ActionResult> AddUserRoles([FromBody] IsuuesLokupTable IT)
        {
            var userRole = await _context.IsuuesLokupTables.SingleOrDefaultAsync(x => x.LokupId == IT.LokupId);

            if (await TypesExist(IT.LokupValue.ToString())) return BadRequest("صلحية المستخدم موجود مسبقا");
            else
            {
                IT.LokupType=5;
                await _context.IsuuesLokupTables.AddAsync(IT);
                await _context.SaveChangesAsync();

            }
            return Ok(true);
        }

      
       
        
          [HttpGet("GetUserRole/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUserRole(int id)
        {
           var userRole = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==5);
            
            if(userRole == null) return NotFound($"userRole with Id = {id} not found");
             
            
            return Ok(userRole);
        }

             [HttpPut("UpdateUserRole/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUserRole(int id ,[FromBody] IsuuesLokupTable it)
        {
           var userRole = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==5);

            if(userRole == null) return NotFound($"userRole with Id = {id} not found");
          
             userRole.LokupType=5;
             userRole.LokupId=it.LokupId;
             userRole.LokupValue=it.LokupValue;

            await _context.SaveChangesAsync();
            return Ok(userRole);
        }


          [HttpDelete("DeleteUserRole/{id}")]
         public async Task<ActionResult> DeleteUserRole(int id)
        {

            try
            {
                var userRole = await _context.IsuuesLokupTables.FirstOrDefaultAsync(o => o.LokupId == id && o.LokupType==5);
                if (userRole == null)
                {
                    return NotFound($"userRole with Id = {id} not found");
                }
                _context.Remove(userRole);
                await _context.SaveChangesAsync();
                return Ok(userRole);
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