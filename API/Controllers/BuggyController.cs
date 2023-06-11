using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController: Controller
    {

       private readonly LawerDataContext _context;

        public BuggyController(LawerDataContext context)
        {
            _context= context;
        }


        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecrets(){
            return "secert text";
        }


        //  [HttpGet("not-found")]
        // public ActionResult<AppUser> GetNotFound(){
        //    var thing = _context.Users.Find(-1);
        //    if(thing == null) return NotFound();
        //    return thing;
        // }


        //  [HttpGet("server-error")]
        // public ActionResult<string> GetServerError(){
        //    var thing = _context.Users.Find(-1);
        //    var thingToReturn = thing.ToString();
        //    return thingToReturn;
        // }


         [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest(){
            return BadRequest("This was not a good request");
        }

        
        
    }
}