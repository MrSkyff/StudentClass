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

        public HomeController(IUser users)
        {
            this.users = users;
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
                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        // Refreshing the authentication session should be allowed.

                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims), authProperties);
                    return Redirect("/Account");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Not correct password");
                }

            }

            return View(model);

        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                users.RegisterUser(model);

                var claims = users.getClaims(new LoginViewModel { Email = model.Email, Pass = model.Pass });
                if (claims != null)
                {
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims));
                    return Redirect("/Account");
                }
                else
                {
                    ModelState.AddModelError("", "ERROR");
                }
                #region
                //var newSalt = SecurityHelper.GenerateSalt(43);
                //var newHash = SecurityHelper.HashPassword(model.Pass, newSalt, 58, 43);

                //User user = new User()
                //{
                //    FirstName = model.FirstName,
                //    LastName = model.LastName,
                //    Email = model.Email,
                //    HashPassword = newHash,
                //    Salt = newSalt
                //};
                ////dbContext.Add(user);
                ////dbContext.SaveChanges();
                //var newModel = new LoginViewModel { Email = model.Email, Pass = model.Pass };
                //var newClaim = users.getClaims(newModel);
                //if (newClaim != null)
                //{
                //    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(newClaim));
                //    return Redirect("/Account");
                //}
                #endregion
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
