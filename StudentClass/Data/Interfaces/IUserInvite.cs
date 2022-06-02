using StudentClass.Data.Models;

namespace StudentClass.Data.Interfaces
{
    public interface IUserInvite
    {
        IEnumerable<Role> GetRolesSelectList();
        void SaveCreate(UserInvite model);
        IEnumerable<UserInvite> GetInviteList();
        UserInvite GetUserInviteCode(string inviteCode);
        bool IsInviteEmailExist(string email);
        UserInvite GetInviteById(int id);
        UserInvite GetInviteByEMail(string eMail);
    }
}
