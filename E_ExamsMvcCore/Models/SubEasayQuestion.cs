using System.ComponentModel.DataAnnotations;

namespace E_ExamsMvcCore.Models
{
    public class SubEasayQuestion
    {
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Question Text")]
        public string QuestionText { get; set; }

        [Display(Name = "Easay Question")]
        public int EasayQuestionId { get; set; }
        public EasayQuestion? EasayQuestion { get; set; }
    }
}
