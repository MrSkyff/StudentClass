using StudentClass.Data.Interfaces;
using StudentClass.Data.Models;
using StudentClass.ViewModels.UserPass;
using System.Security.Claims;

namespace StudentClass.Data.Repository
{
    public class UserMocks : IUser
    {
        public IEnumerable<User> Users => throw new NotImplementedException();

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ClaimsIdentity getClaims(LoginViewModel loginViewModel)
        {
            throw new NotImplementedException();
        }

        public bool IsEmailExist(string email)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(RegisterViewModel registerViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
