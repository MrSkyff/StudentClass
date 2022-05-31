using Microsoft.AspNetCore.Mvc;
using StudentClass.Data.Interfaces;
using StudentClass.Data.Models;


namespace StudentClass.Controllers
{
    public class UserInviteController : Controller
    {
        private readonly IUserInvite userInvite;

        public UserInviteController(IUserInvite userInvite)
        {
            this.userInvite = userInvite;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateInvite()
        {
            UserInvite model = new UserInvite();
            model.RoleSelector = userInvite.GetRolesSelectList();

            return View(model);
        }
        [HttpPost]
        public IActionResult CreateInvite(UserInvite model)
        {
            model.InviteCode = Guid.NewGuid().ToString();
            model.Status = 0;
            model.CreatedBy = "Admin";
            model.Created = DateTime.Now;
            model.UseDate = default;
            userInvite.SaveCreate(model);
            return RedirectToAction("Index");
        }
    }
}
