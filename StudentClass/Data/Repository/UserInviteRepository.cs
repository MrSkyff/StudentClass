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
        public IEnumerable<Role> GetRolesSelectList()
        {
            //IEnumerable<Role> selectedLists = new List<Role>()
            //{
            //new Role{ Id = 1, Name = "Admin" },
            //new Role{ Id = 2, Name = "Teacher" },
            //new Role{ Id = 3, Name = "Student" }
            //};
            //var selected = selectedLists;

            var selected = dbContext.Roles.ToList();

            return selected;
        }

        public void SaveCreate(UserInvite model)
        {
            if (model.Id <= 0) { dbContext.UserInvites.Add(model); }
            else { dbContext.UserInvites.Update(model); }
            dbContext.SaveChanges();
        }
    }
}
