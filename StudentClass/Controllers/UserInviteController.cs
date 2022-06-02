using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentClass.Data.Interfaces;
using StudentClass.Data.Models;
using StudentClass.ViewModels.UserInvite;

namespace StudentClass.Controllers
{

    //[Authorize(Roles = "Admin, admin")]
    [Authorize(Policy = "AdminArea")]
    public class UserInviteController : Controller
    {
        private readonly IUserInvite userInvite;

        public UserInviteController(IUserInvite userInvite)
        {
            this.userInvite = userInvite;
        }

        public IActionResult Index()
        {
            return View(userInvite.GetInviteList().ToList());
        }
        public IActionResult CreateInvite() => View(new UserInviteViewModel() { RoleSelector = userInvite.GetRolesSelectList() });

        [HttpPost]
        public IActionResult CreateInvite(UserInvite model)
        {
            model.InviteCode = Guid.NewGuid().ToString();
            model.Status = (int)InviteStatus.Active;
            model.CreatedBy = "Admin"; //Temp! Will be recpalced by active user.
            model.Created = DateTime.Now;
            model.UseDate = default;
            userInvite.SaveCreate(model);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsEmailNotExist(string email)
        {
            if (userInvite.IsInviteEmailExist(email))
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}
