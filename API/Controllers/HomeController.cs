using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    
    public class HomeController : ControllerBase
    {
        // private readonly DbA436e9Dbslam1Context _DbContext;

        // public HomeController(DbA436e9Dbslam1Context dbContext)
        // {
        //     _DbContext = dbContext;
        // }

        // [HttpGet]
        // public async Task<ActionResult> Index()
        // {
        //         var tabname = await (from values in _DbContext.Tabs
        //         select values.TabName).ToArrayAsync();
        //         return Ok(tabname);
        
        // }

    }
}