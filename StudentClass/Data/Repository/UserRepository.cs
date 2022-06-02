
using Microsoft.EntityFrameworkCore;
using StudentClass.Data.Helpers;
using StudentClass.Data.Interfaces;
using StudentClass.Data.Models;
using StudentClass.ViewModels.UserPass;
using System.Security.Claims;

namespace StudentClass.Data.Repository
{
    public class UserRepository : IUser
    {
        private readonly ApplicationContext context;
        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> Users => context.Users;

        public User GetById(int id) => context.Users.FirstOrDefault(u => u.Id == id);

        public ClaimsPrincipal getClaims(LoginViewModel loginViewModel)
        {
            var currentUser = context.Users.FirstOrDefault(x => x.Email.ToLower().Equals(loginViewModel.Email.ToLower()));
            
            if (currentUser != null)
            { 
                string heshPassword = SecurityHelper.HashPassword(loginViewModel.Pass, currentUser.Salt, 58, 43);
                if (heshPassword.Equals(currentUser.HashPassword))
                {
                    var userRoles = GetUserRoles(currentUser.Id);
                    var claims = new List<Claim>
                    {
                        new Claim("Id", currentUser.Id.ToString()),
                        new Claim(ClaimTypes.Name, currentUser.FirstName.ToString() + " " + currentUser.LastName),
                        //new Claim(ClaimsIdentity.DefaultRoleClaimType, userRoles.ToString())
                    };

                    foreach (var item in userRoles)
                    {
                        claims.Add(new Claim("Role", item.Name));
                    }

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "SC_Cookies");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    return claimsPrincipal;
                }
            }

            return null;
        }

        public IEnumerable<Role> GetUserRoles(int id)
        {
            return context.Roles.Include(r => r.UserRoles).Where(c=>c.UserRoles.Any(u=>u.UserId == id));
        }

        public bool IsEmailExist(string email) => context.Users.Any(x => x.Email.ToLower().Equals(email.ToLower()));
        

        public void RegisterUser(RegisterViewModel registerViewModel)
        {
            string salt = SecurityHelper.GenerateSalt(43);
            string hashPass = SecurityHelper.HashPassword(registerViewModel.Pass, salt, 58, 43);

            context.Users.Add(new User()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                Salt = salt,
                HashPassword = hashPass
            });

            context.SaveChanges();

        }
    }
}
