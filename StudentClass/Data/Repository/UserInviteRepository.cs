using StudentClass.Data.Interfaces;
using StudentClass.Data.Models;

namespace StudentClass.Data.Repository
{
    public class UserInviteRepository : IUserInvite
    {
        private readonly ApplicationContext dbContext;

        public UserInviteRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserInvite GetInviteByEMail(string eMail) => dbContext.UserInvites.FirstOrDefault(x => x.EMail == eMail)!;
        

        public UserInvite GetInviteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserInvite> GetInviteList()
        {
            return dbContext.UserInvites;
        }

        public IEnumerable<Role> GetRolesSelectList() => dbContext.Roles;

        public UserInvite GetUserInviteCode(string inviteCode)
        {
            return dbContext.UserInvites.SingleOrDefault(x => x.InviteCode == inviteCode);
        }

        public bool IsInviteEmailExist(string email)
        {
            List<bool> list = new List<bool>();
            list.Add(dbContext.UserInvites.Any(x => x.EMail.ToLower().Equals(email.ToLower())));
            list.Add(dbContext.Users.Any(x => x.Email.ToLower().Equals(email.ToLower())));

            return list.Any(c => c);
        }

        public void SaveCreate(UserInvite model)
        {
            if (model.Id <= 0) { dbContext.UserInvites.Add(model); }
            else { dbContext.UserInvites.Update(model); }
            dbContext.SaveChanges();
        }
    }
}
