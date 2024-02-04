using E_ExamsMvcCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_ExamsMvcCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<E_ExamsMvcCore.Models.EasayQuestion> EasayQuestion { get; set; } = default!;
        public DbSet<E_ExamsMvcCore.Models.SubEasayQuestion> SubEasayQuestion { get; set; } = default!;
    }
}
