using Microsoft.AspNetCore.Mvc;

namespace StudentClass.Areas.ClassRoom.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Show()
        {
            return View();
        }
    }
}
