using E_ExamsMvcCore.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_ExamsMvcCore.Models
{
    public class Lecturer : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string SurName { get; set; }
        [Display(Name = "Other Name")]
        public string OtherName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Course>? Courses { get; set; }

        public string FullName
        {
            get
            {
                return $"{SurName} {FirstName} {OtherName}";
            }
        }

    }
}
