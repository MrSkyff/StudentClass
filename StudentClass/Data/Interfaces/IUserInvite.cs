using StudentClass.Data.Models;

namespace StudentClass.Data.Interfaces
{
    public interface IUserInvite
    {
        IEnumerable<Role> GetRolesSelectList();
        void SaveCreate(UserInvite model);
    }
}
