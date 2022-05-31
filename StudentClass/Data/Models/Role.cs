using System.ComponentModel.DataAnnotations;

namespace StudentClass.Data.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserRoles> UserRoles { get; set; }
    }
}
