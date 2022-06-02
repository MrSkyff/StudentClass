using Microsoft.AspNetCore.Mvc;

namespace StudentClass.Areas.ClassRoom.Controllers
{
    public class ContentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
