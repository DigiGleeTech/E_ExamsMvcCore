using System.ComponentModel.DataAnnotations;

namespace E_ExamsMvcCore.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Course")]
        public string CourseName { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        [Display(Name = "Lecturer")]
        public string LecturerId { get; set; }
        public Lecturer? Lecturer { get; set; }
    }
}
