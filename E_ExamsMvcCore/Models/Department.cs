namespace E_ExamsMvcCore.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public ICollection<Candidate>? Candidates { get; set; }
        public ICollection<Lecturer>? Lecturers { get; set; }
    }
}
