using System.ComponentModel.DataAnnotations;

namespace E_ExamsMvcCore.Models
{
    public class EasayQuestion
    {
        public int Id { get; set; }
        public string? Instruction { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name="Question Text")]
        public  string QuestionContent { get; set; }

        [Display(Name = "Exam")]
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }
        public ICollection<SubEasayQuestion>? SubEasayQuestions { get; set; }
    }
}
