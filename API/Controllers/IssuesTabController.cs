using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.VisualBasic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssuesTabController : Controller
    {
        private readonly LawerDataContext _context;

        public IssuesTabController(LawerDataContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet("GetAgencies")]
        public async Task<ActionResult> GetAgencies()
        {
            var agencies = await _context.IsuuesAgencies.ToListAsync();
            return Ok(agencies);
        }

        [HttpPost("AddAgency")]
        public async Task<ActionResult> AddAgency([FromBody] IsuuesAgency lawer)
        {
            var agence = await _context.IsuuesAgencies.SingleOrDefaultAsync(x => x.AgenceId == lawer.AgenceId);

            if (await AgenceNoExist(lawer.AgenceNo.ToString())) return BadRequest("رقم الوكالة موجود مسبقا");
            else
            {
                // agence.AgenceName = lawer.AgenceName;
                // agence.AgenceTo = lawer.AgenceTo;
                // agence.AgenceNo = lawer.AgenceNo;
                // agence.AgenceNote = lawer.AgenceNote;
                // agence.AgenceType = lawer.AgenceType;

                await _context.IsuuesAgencies.AddAsync(lawer);
                await _context.SaveChangesAsync();

            }
            return Ok(true);
        }
         [HttpGet("GetAgent/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetAgent(int id)
        {
           var agent = await _context.IsuuesAgencies.FirstOrDefaultAsync(o => o.AgenceId == id);
            
            if(agent == null) return NotFound($"Agency with Id = {id} not found");
             
            
            return Ok(agent);
        }

         [HttpPut("UpdateAgent/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAgent(long id ,[FromBody] IsuuesAgency lawer)
        {
           var agent = await _context.IsuuesAgencies.FindAsync(id);
            
            if(agent == null) return NotFound($"Agency with Id = {id} not found");
            if (await AgenceNoExist(lawer.AgenceNo.ToString())) return BadRequest("رقم الوكالة موجود مسبقا");
             agent.IsuueNumber = lawer.IsuueNumber;
             agent.AgenceNo = lawer.AgenceNo;
             agent.AgenceTo = lawer.AgenceTo;
             agent.AgenceName = lawer.AgenceName;
             agent.AgenceNote = lawer.AgenceNote;
             agent.AgenceType = lawer.AgenceType;
            
            await _context.SaveChangesAsync();
            return Ok(agent);
        }

        [HttpDelete("DeleteAgency/{id}")]
        public async Task<ActionResult> DeleteAgency(int id)
        {

            try
            {
                var agency = await _context.IsuuesAgencies.FirstOrDefaultAsync(o => o.AgenceId == id);
                if (agency == null)
                {
                    return NotFound($"Agency with Id = {id} not found");
                }
                _context.Remove(agency);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting Agency");
            }


        }
        private async Task<bool> AgenceNoExist(string AgenceNo)
        {
            return await _context.IsuuesAgencies.AnyAsync(x => x.AgenceNo.ToString() == AgenceNo);
        }

           private async Task<bool> IssueNo(string IssueNo)
        {
            return await _context.Isuues.AnyAsync(x => x.Isuuenumber == IssueNo);
        }

        //--------------------------------------------------------
        [HttpGet("GetIssuesNumber")]
        public async Task<ActionResult> GetIssuesNumber()
        {
            var issueNumbers = await _context.Isuues.Select(x => x.Isuuenumber).ToListAsync();
            return Ok(issueNumbers);
        }

        [HttpGet("GetIssuesSubject")]
        public async Task<ActionResult> GetIssuesSubject()
        {
            var issueSubjects = await _context.Isuues.Select(x => x.IsuueSubject).ToListAsync();
            return Ok(issueSubjects);
        }

        [HttpGet("GetLokupAgenceTypes")]
        public async Task<ActionResult> GetLokupAgenceTypes()
        {
            var types = await (from b in _context.IsuuesLokupTables
                               where b.LokupType == 1
                               select new
                               {
                                   b.LokupId,
                                   b.LokupValue
                               }).ToListAsync();
            return Ok(types);
        }

        [HttpGet("GetAgenceType")]
        public async Task<ActionResult> GetAgenceType()
        {
            var agenceType =
            await (from a in _context.IsuuesAgencies
                   join b in _context.IsuuesLokupTables
            on a.AgenceType equals b.LokupId
                   // join k in _context.IsuuesLokupTables on  a.IsuueType equals k.LokupId
                   where b.LokupType == 1
                   select new { b.LokupValue }).ToListAsync();

            return Ok(agenceType);
        }

        [HttpGet("GetIssueStatus")]
        public async Task<ActionResult> GetIssueStatus()
        {
            var issuesStatus =
            await (from a in _context.Isuues
                   join b in _context.IsuuesAgencies
            on a.Isuuenumber equals b.IsuueNumber
                   join k in _context.IsuuesLokupTables on a.IsuueStatus equals k.LokupId
                   where k.LokupType == 2
                   join l in _context.IsuuesLokupTables on b.AgenceType equals l.LokupId
                   where l.LokupType == 1
                   select new { k.LokupValue,b.AgenceType, b.AgenceNo, b.AgenceName, b.AgenceTo, b.AgenceId, b.AgencePic, at= l.LokupValue}).ToListAsync();



            return Ok(issuesStatus);
        }


          
//..............................................................................

   [HttpGet("GetIssues")]
        public async Task<ActionResult> GetIssues()
        {
            var issues = await _context.Isuues.ToListAsync();
            return Ok(issues);
        }

         [HttpGet("GetIssuesTable")]
        public async Task<ActionResult> GetIssuesTable()
        {
            var issues = await (from a in _context.IsuuesLokupTables
                   join b in _context.Isuues
            on a.LokupId equals b.IsuueStatus
                   // join k in _context.IsuuesLokupTables on  a.IsuueType equals k.LokupId
                   where a.LokupType == 2
                   select new { a.LokupValue,b.Isuuenumber,b.IsuueId,b.IsuueSubject,b.IsuueOpenDate,b.IsuueStatus }).ToListAsync();
            return Ok(issues);
        }


           [HttpGet("GetDoneIssues")]
        public async Task<ActionResult> GetDoneIssues()
        {
            var doneIssues =  await _context.Isuues.Where(x=>x.IsuueStatus==4).CountAsync();
            return Ok(doneIssues);
        }


         [HttpGet("LokupTable")]
        public async Task<ActionResult> LokupTable()
        {
            var lokup = await _context.IsuuesLokupTables.ToListAsync();
            return Ok(lokup);
        }

        

            [HttpGet("IssueType")]
        public async Task<ActionResult> IssueType()
        {
            var lokup = await _context.IsuuesLokupTables.Where(x=> x.LokupType==1).ToListAsync();
            return Ok(lokup);
        }

           [HttpGet("IssueTable")]
        public async Task<ActionResult> IssueTable()
        {
           var issues = await (from a in _context.Isuues
                   join b in _context.Customers
            on a.CustomerId equals b.CustId
                   join k in _context.IsuuesLokupTables on a.IsuueStatus equals k.LokupId
                   where k.LokupType == 2
                   join l in _context.IsuuesLokupTables on a.IsuueType equals l.LokupId
                   where l.LokupType == 1
                   select new { k.LokupValue, a.Isuuenumber , a.IsuueId, b.CustName , at= l.LokupValue}).ToListAsync();
            return Ok(issues);
        }

          [HttpGet("ContractType")]
        public async Task<ActionResult> ContractType()
        {
            var lokup = await _context.IsuuesLokupTables.Where(x=> x.LokupType==3).ToListAsync();
            return Ok(lokup);
        }

 [HttpGet("CustomerType")]
        public async Task<ActionResult> CustomerType()
        {
            var CT = await _context.IsuuesLokupTables.Where(x=> x.LokupType==4).ToListAsync();
            return Ok(CT);
        }

            [HttpPost("AddService")]
        public async Task<ActionResult> AddService([FromBody] Isuue issue)
        {
            var agence = await _context.Isuues.SingleOrDefaultAsync(x => x.IsuueId == issue.IsuueId);

            if (await IssueNo(issue.Isuuenumber)) return BadRequest("رقم القضية موجود مسبقا");
            else
            {
                await _context.Isuues.AddAsync(issue);
                await _context.SaveChangesAsync();

            }
            return Ok(true);
        }


          [HttpGet("GetIssue/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetIssue(int id)
        {
           var agent = await _context.Isuues.FirstOrDefaultAsync(o => o.IsuueId == id);
            
            if(agent == null) return NotFound($"Agency with Id = {id} not found");
             
            
            return Ok(agent);
        }

         [HttpPut("UpdateIssue/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateIssue(long id ,[FromBody] Isuue isuue)
        {
           var issue = await _context.Isuues.FindAsync(id);
            
            if(issue == null) return NotFound($"Issue with Id = {id} not found");
            
             issue.IsuueSubject = isuue.IsuueSubject;
             issue.Isuuenumber = isuue.Isuuenumber;
             issue.IsuueOpenDate = isuue.IsuueOpenDate;
             issue.ContractType = isuue.ContractType;
             issue.IsuueType = isuue.IsuueType;
             issue.CustomerId = isuue.CustomerId;
             issue.IsseName = isuue.IsseName;
             issue.CourtCity = isuue.CourtCity;
             issue.CourtCircle = isuue.CourtCircle;
             issue.CustomerType = isuue.CustomerType;
             issue.IsuueSummary = isuue.IsuueSummary;
             issue.IsuueDetail = isuue.IsuueDetail;
             issue.LowerName = isuue.LowerName;
             issue.ContractNumber = isuue.ContractNumber;
             issue.AgnName = isuue.AgnName;
             issue.Agnaddress = isuue.Agnaddress;
             issue.Agnphone = isuue.Agnphone;

            await _context.SaveChangesAsync();
            return Ok(issue);
        }

          [HttpDelete("DeleteIssue/{id}")]
        public async Task<ActionResult> DeleteIssue(int id)
        {

            try
            {
                var issue = await _context.Isuues.FirstOrDefaultAsync(o => o.IsuueId == id);
                if (issue == null)
                {
                    return NotFound($"Issue with Id = {id} not found");
                }
                _context.Remove(issue);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting Issue");
            }


        }
//--------------------------------------------------------------------------------------

   [HttpGet("GetSessions")]
        public async Task<ActionResult> GetSessions()
        {
            var sessions = await _context.IsuuesSessions.ToListAsync();
            return Ok(sessions);
        }

        
           [HttpGet("GetSessionsTable")]
        public async Task<ActionResult> GetSessionsTable()
        {
           var sessions = await (from a in _context.Isuues
                   join b in _context.IsuuesSessions
            on a.Isuuenumber equals b.AisuueNumber.ToString()
                   join k in _context.IsuuesLokupTables on a.IsuueType equals k.LokupId
                   where k.LokupType == 1
              
                   select new { k.LokupValue, b.SessionId,b.SessionName}).ToListAsync();
            return Ok(sessions);
        }

  [HttpPost("AddSession")]
        public async Task<ActionResult> AddSession([FromBody] IsuuesSession session)
        {
            var agence = await _context.IsuuesSessions.SingleOrDefaultAsync(x => x.SessionId == session.SessionId);

           
                await _context.IsuuesSessions.AddAsync(session);
                await _context.SaveChangesAsync();

            
            return Ok(true);
        }

         [HttpGet("GetSession/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetSession(int id)
        {
           var session = await _context.IsuuesSessions.FirstOrDefaultAsync(o => o.SessionId == id);
            
            if(session == null) return NotFound($"session with Id = {id} not found");
             
            
            return Ok(session);
        }

             [HttpPut("UpdateSession/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateSession(long id ,[FromBody] IsuuesSession ses)
        {
           var session = await _context.IsuuesSessions.FindAsync(id);
            
            if(session == null) return NotFound($"session with Id = {id} not found");
          
             session.AisuueNumber = ses.AisuueNumber;
             session.SessionName = ses.SessionName;
             session.SessionNote = ses.SessionNote;
             session.SessionDate = ses.SessionDate;
             session.SessionNextName = ses.SessionNextName;
             session.SessionNextDate = ses.SessionNextDate;
             session.CustomerInv = ses.CustomerInv;

            await _context.SaveChangesAsync();
            return Ok(session);
        }


   [HttpDelete("DeleteSession/{id}")]
        public async Task<ActionResult> DeleteSession(int id)
        {

            try
            {
                var session = await _context.IsuuesSessions.FirstOrDefaultAsync(o => o.SessionId == id);
                if (session == null)
                {
                    return NotFound($"Issue with Id = {id} not found");
                }
                _context.Remove(session);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting Issue");
            }


        }


        //------------------------------------------------------------------------------

           [HttpGet("GetConsulting")]
        public async Task<ActionResult> GetConsulting()
        {
            var Consulting = await (from a in _context.Consultings
                   join b in _context.Customers
            on a.CustomerId equals b.CustId
                   join k in _context.IsuuesLokupTables on a.ConstType equals k.LokupId
                   where k.LokupType == 4
                   select new { k.LokupValue, b.CustName,a.ConstSubject,a.ConstType,a.Result,a.ConsuultingId}).ToListAsync();
            return Ok(Consulting);
        }


          [HttpPost("AddConsulting")]
        public async Task<ActionResult> AddConsulting([FromBody] Consulting consulting)
        {
            var constult = await _context.Consultings.SingleOrDefaultAsync(x => x.ConsuultingId == consulting.ConsuultingId);

                await _context.Consultings.AddAsync(consulting);
                await _context.SaveChangesAsync();

            
            return Ok(true);
        }

          [HttpGet("GetConsulting/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetConsulting(int id)
        {
           var consulting = await _context.Consultings.FirstOrDefaultAsync(o => o.ConsuultingId == id);
            
            if(consulting == null) return NotFound($"consulting with Id = {id} not found");
             
            
            return Ok(consulting);
        }

             [HttpPut("UpdateConsulting/{id}")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateConsulting(int id ,[FromBody] Consulting consult)
        {
           var consulting = await _context.Consultings.FindAsync(id);

            if(consulting == null) return NotFound($"consulting with Id = {id} not found");
          
             consulting.ConstType = consult.ConstType;
             consulting.ConstSubject = consult.ConstSubject;
             consulting.CustomerId = consult.CustomerId;
             consulting.Result = consult.Result;

            await _context.SaveChangesAsync();
            return Ok(consulting);
        }

   [HttpDelete("DeleteConsulting/{id}")]
        public async Task<ActionResult> DeleteConsulting(int id)
        {

            try
            {
                var consult = await _context.Consultings.FirstOrDefaultAsync(o => o.ConsuultingId == id);
                if (consult == null)
                {
                    return NotFound($"Issue with Id = {id} not found");
                }
                _context.Remove(consult);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting Issue");
            }


        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}