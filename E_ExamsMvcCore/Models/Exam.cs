using E_ExamsMvcCore.Enums;
using System.ComponentModel.DataAnnotations;

namespace E_ExamsMvcCore.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Display(Name = "Doration")]
        public int Duration { get; set; }
        [Display(Name = "Exam Type")]
        public ExamType ExamType { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public ICollection<Question>? Questions { get; set; }
        public ICollection<EasayQuestion>? EasayQuestions { get; set; }
    }
}
