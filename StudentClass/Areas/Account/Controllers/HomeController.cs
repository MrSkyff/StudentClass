using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudentClass.Areas.Account.Controllers
{
    [Authorize]
    [Area("Account")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = HttpContext.User.Identity;
            var userName = user.Name;
            return View();
        }
    }
}
