using Microsoft.EntityFrameworkCore;

namespace JISA_Student_Assignment.Entities
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<Student> Students { get; set; }


    }
}
