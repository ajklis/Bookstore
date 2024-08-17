using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllBooks()
        {

        }
    }
}
