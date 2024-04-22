using Microsoft.AspNetCore.Mvc;

namespace DotNetWithSQLiteUsingDapper.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
