using JISA_Student_Assignment.Entities;

namespace JISA_Student_Assignment.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
        int AddStudent(Student student);
        int UpdateStudent(Student student);
        int DeleteStudent(int id);
    }
}
