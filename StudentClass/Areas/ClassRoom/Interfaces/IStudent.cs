using StudentClass.Areas.ClassRoom.Models;

namespace StudentClass.Areas.ClassRoom.Interfaces
{
    public interface IStudent
    {
        IEnumerable<Student> studentList();
        Student GetStudentById(int id);
    }
}
