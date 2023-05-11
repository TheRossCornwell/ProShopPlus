using Microsoft.AspNetCore.Mvc;

namespace ProShopPlus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProShopPlus.Data.ProShopPlusContext _context;
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("GetContactNames")]
        public IActionResult GetContactNames(string term)
        {
            var a = _context.Contact.Where(c => c.Name.StartsWith(term)).Select(a => new { label = a.Name, id = a.ID });

            if (a is null)
            {
                return NotFound(term);
            }
            return Ok(a);
        }


    }
}
