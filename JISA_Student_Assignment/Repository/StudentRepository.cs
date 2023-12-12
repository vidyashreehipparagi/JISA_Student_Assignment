using JISA_Student_Assignment.Entities;

namespace JISA_Student_Assignment.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext context;
        public StudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int AddStudent(Student student)
        {
            int result = 0;
            student.IsActive = 1;
            context.Students.Add(student);
            result = context.SaveChanges();
            return result;
        }

        public int DeleteStudent(int id)
        {
            int result = 0;
            var student = context.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student != null)
            {
                student.IsActive = 0;
                result = context.SaveChanges();
            }
            return result;
        }

        public Student GetStudentById(int id)
        {
            int result = 0;
            var student = context.Students.Where(x => x.Id == id).FirstOrDefault();
            return student;
        }

        public IEnumerable<Student> GetStudents()
        {
            return context.Students.Where(x => x.IsActive == 1).ToList();
        }

        public int UpdateStudent(Student student)
        {
            int result = 0;
            var b = context.Students.Where(x => x.Id == student.Id).FirstOrDefault();
            if (b != null)
            {
                b.Name = student.Name;
                b.Marks = student.Marks;
                b.Course = student.Course;
                b.IsActive = 1;
                result = context.SaveChanges();
            }
            return result;
        }
    }
}
