using E_ExamsMvcCore.Enums;
using System.ComponentModel.DataAnnotations;

namespace E_ExamsMvcCore.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public EnumCurrectOptions CurrectOption { get; set; }

        [Display(Name = "Exam")]
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }
    }
}
