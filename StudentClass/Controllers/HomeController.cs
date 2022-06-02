using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentClass.Data;
using StudentClass.Data.Helpers;
using StudentClass.Data.Interfaces;
using StudentClass.Data.Models;
using StudentClass.ViewModels.UserPass;
using System.Security.Claims;

namespace StudentClass.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUser users;
        private readonly IUserInvite userInvite;

        public HomeController(IUser users, IUserInvite userInvite)
        {
            this.users = users;
            this.userInvite = userInvite;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsEmailExist(string email)
        {
            if (users.IsEmailExist(email))
            {
                return Json(true);
            }
            return Json(false);
        }

        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsEmailNotExist(string email)
        {
            if (users.IsEmailExist(email))
            {
                return Json(false);
            }
            return Json(true);
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) { return Redirect("/Account"); }

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var claims = users.getClaims(model);
                if (claims != null)
                {
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims));
                    return Redirect("/Account");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Not correct password");
                }

            }

            return View(model);

        }
        [HttpGet]
        public IActionResult Register(string inviteCode)
        {
            UserInvite userInviteCheck = userInvite.GetUserInviteCode(inviteCode);
            RegisterViewModel model = new RegisterViewModel();
            if (userInviteCheck != null && userInviteCheck.Status == (int)InviteStatus.Active)
            {
                model.Email = userInviteCheck.EMail;
                model.FirstName = userInviteCheck.FirstName;
                model.LastName = userInviteCheck.LastName;
                model.InviteCode = true;
            }
            else { model.InviteCode = false; }

            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                users.RegisterUser(model);

                var claims = users.getClaims(new LoginViewModel { Email = model.Email, Pass = model.Pass });

                UserInvite userInviteUpdate = userInvite.GetInviteByEMail(model.Email!);
                userInviteUpdate.Status = (int)InviteStatus.Used;
                userInvite.SaveCreate(userInviteUpdate);

                if (claims != null)
                {
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims));
                    return Redirect("/Account");
                }
                else
                {
                    ModelState.AddModelError("", "ERROR");
                }
            }
            return View(model);
        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
