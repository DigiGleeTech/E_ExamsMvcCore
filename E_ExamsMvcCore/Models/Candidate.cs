using E_ExamsMvcCore.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_ExamsMvcCore.Models
{
    public class Candidate : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }    
        public string SurName { get; set; }
        [Display(Name = "Other Name")]
        public string OtherName { get; set; }

        [Display(Name = "Candidate Number")]
        public string? CandidateNumber { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public Candidate()
        {
            CandidateNumber = $"ST/FPB/ND/{CandidateNumberGenerator.GenerateRandomNumber(1000).ToString()}";
        }
    }

   public static class CandidateNumberGenerator
    {
        public static int GenerateRandomNumber(int seed)
        {
            // Create a new instance of the Random class with the specified seed
            Random random = new Random(seed);

            // Generate a random integer
            int randomNumber = random.Next();
            Console.WriteLine($"Random Number: {randomNumber}");

            // Generate a random double between 0.0 and 1.0
            double randomDouble = random.NextDouble();
            Console.WriteLine($"Random Double: {randomDouble}");

            // Generate a random number within a specific range (e.g., between 1 and 100)
            int min = 1;
            int max = 9999;
            int randomInRange = random.Next(min, max + 1);

            // Return the generated random number within the specified range
            return randomInRange;
        }
    }

}
