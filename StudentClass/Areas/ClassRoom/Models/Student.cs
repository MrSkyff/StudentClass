using StudentClass.Data.Models;

namespace StudentClass.Areas.ClassRoom.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
