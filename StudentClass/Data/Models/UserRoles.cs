using System.ComponentModel.DataAnnotations;

namespace StudentClass.Data.Models
{
    public class UserRoles
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
