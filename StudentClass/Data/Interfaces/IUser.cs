using StudentClass.Data.Models;
using System.Security.Claims;
using StudentClass.ViewModels.UserPass;

namespace StudentClass.Data.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> Users { get; }
        User GetById(int id);
        ClaimsIdentity getClaims(LoginViewModel loginViewModel);
        void RegisterUser(RegisterViewModel registerViewModel);
        bool IsEmailExist(string email);
    }
}
