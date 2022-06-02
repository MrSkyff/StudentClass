using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentClass.Data;
using StudentClass.Data.Interfaces;
using StudentClass.Data.Models;

namespace StudentClass.Areas.Manager.Controllers
{
    [Authorize]
    [Area("Manager")]
    public class UserController : Controller
    {
        private readonly ApplicationContext dbContext;
        private readonly IUser usersRepository;

        public UserController(ApplicationContext dbContext, IUser usersRepository)
        {
            this.dbContext = dbContext;
            this.usersRepository = usersRepository;
        }

        public IActionResult Index()
        {
            var model = dbContext.Users.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(usersRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(User model)
        {
            return View();
        }
    }
}
