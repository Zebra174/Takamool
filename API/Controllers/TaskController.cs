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
            var tasks = await _context.Tasks.ToListAsync();
            return Ok(tasks);
        }

         [HttpPost("AddTask")]
        public async Task<ActionResult> AddTask([FromBody] Models.Task task)
        {
            var task1 = await _context.Tasks.SingleOrDefaultAsync(x => x.TaskId == task.TaskId);

            
                await _context.Tasks.AddAsync(task);
                await _context.SaveChangesAsync();

            
            return Ok(true);
        }

          private async Task<bool> TaskTitleExist(string? title)
        {
            return await _context.Tasks.AnyAsync(x => x.Title == title);
        }


        [HttpGet("GetStatuses")]
        public async Task<ActionResult> GetStatuses()
        {
            var statuses = await _context.IsuuesLokupTables.Where(x=>x.LokupType==2).ToListAsync();
            return Ok(statuses);
        }
       

         [HttpGet("GetTaskStatus")]
        public async Task<ActionResult> GetTaskStatus()
        {
            var tasksStatus = await (from a in _context.IsuuesLokupTables
                   join b in _context.Tasks
            on a.LokupId equals b.TaskStatus
                   // join k in _context.IsuuesLokupTables on  a.IsuueType equals k.LokupId
                   where a.LokupType == 2
                   select new { a.LokupValue }).ToListAsync();
            return Ok(tasksStatus);
        }

         [HttpGet("GetTaskTableValues")]
        public async Task<ActionResult> GetTaskTableValues()
        {
            var tasksStatus = await (from a in _context.IsuuesLokupTables
                   join b in _context.Tasks
            on a.LokupId equals b.TaskStatus
                   // join k in _context.IsuuesLokupTables on  a.IsuueType equals k.LokupId
                   where a.LokupType == 2
                   select new { a.LokupValue,b.TaskId,b.TaskStatus,b.Title,b.Description,b.ProjectedStart,b.ProjectedEnd }).ToListAsync();
            return Ok(tasksStatus);
        }


             [HttpGet("GetDoneTask")]
        public async Task<ActionResult> GetDoneTask()
        {
            var doneTasks =  await _context.Tasks.Where(x=>x.TaskStatus==4).CountAsync();
            return Ok(doneTasks);
        }

        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}