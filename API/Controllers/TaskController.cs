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
    public class TaskController : Controller
    {
        private readonly LawerDataContext _context;

        public TaskController(LawerDataContext dbContext)
        {
           _context = dbContext;
        }


  [HttpGet("GetTasks")]
        public async Task<ActionResult> GetTasks()
        {
            var tasks = await _context.TaskTemplates.ToListAsync();
            return Ok(tasks);
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}