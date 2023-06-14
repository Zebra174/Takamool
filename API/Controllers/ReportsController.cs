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
    public class ReportsController : Controller
    { private readonly LawerDataContext _context;

        public ReportsController(LawerDataContext dbContext)
        {
           _context = dbContext;
        }
        
         [HttpGet("GetCustSessions")]
        public async Task<ActionResult> GetCustSessions()
        {
            var sessionIssue = await (from a in _context.Isuues
                   join b in _context.Customers
                   on a.CustomerId equals b.CustId
                  join k in _context.IsuuesLokupTables
                  on a.IsuueType equals k.LokupId
                  where(k.LokupType == 1)
                  join w in _context.IsuuesSessions
                  on a.Isuuenumber equals w.AisuueNumber.ToString()
                   select new { b.CustId,b.CustName,k.LokupValue,a.IsuueSubject,w.SessionDate,a.IsuueType,a.IsseName,a.CourtCircle,a.LowerName }).ToListAsync();
            return Ok(sessionIssue);
        }
        
           

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}