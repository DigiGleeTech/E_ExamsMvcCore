using E_ExamsMvcCore.Data;
using E_ExamsMvcCore.Models;
using E_ExamsMvcCore.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace E_ExamsMvcCore.Controllers
{

    //[Authorize(Policy = "Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            this.db = db;
            this.userManager = userManager;
        }


        [HttpGet]
        public IActionResult ValidateCandiate()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> ValidateCandiateAsync(ValidateCandidateVM validateCandidate)
        {
           
            // Retrieve the CandidateNumber property
            var candidate = db.Candidates.Where(x=>x.CandidateNumber == validateCandidate.CandidateNumber).FirstOrDefault();

            if (candidate != null)
            {
                //var candidate = await userManager.GetUserAsync(User);
                if (validateCandidate.CandidateNumber == candidate.CandidateNumber)
                {
                    ViewBag.CandidateMessage = "Validation Successfully";
                    ViewBag.CandidateNumber = candidate.CandidateNumber;
                    return View("SpeedTest");
                }
                else
                {
                    ViewBag.CandidateNumber = validateCandidate.CandidateNumber;
                    ViewBag.CandidateMessage = "Invalid Candidate Number";
                    return View();
                }
                
            }

            ViewBag.CandidateNumber = validateCandidate.CandidateNumber;
            ViewBag.CandidateMessage = "Invalid Candidate Number";

            return View();            
            
        }

        public IActionResult Index()
        {
            ViewBag.TotalQuestion = db.Questions.Count();
            var exam = db.Questions
               .Include(q => q.Exam)
               .ThenInclude(q => q.Course)
               .ThenInclude(q => q.Department)
               .Include(q => q.Exam.EasayQuestions)
               .ThenInclude(eq => eq.SubEasayQuestions)
               .FirstOrDefault();

            var Easay = db.EasayQuestion
                .Include(x => x.SubEasayQuestions)
                .FirstOrDefault();

            if (exam != null)
            {
                return View(exam);
            }
            else if (Easay != null)
            {
                return PartialView("_EssayQuestionPartial", Easay);
            }
            else
            {
                return Content("Question Available");
            }
           
        }

        [HttpPost]
        public IActionResult Index(Question question)
        {
            return View();
        }

        public IActionResult SpeedTest() 
        {
            return View();
           // return PartialView("_SpeedTest");
        }
        
        public IActionResult Easay() 
        {
            var easay = db.Exams
                .Include(x => x.EasayQuestions)
                .ThenInclude(e => e.SubEasayQuestions)
                .Include(x => x.Course)
                .ThenInclude(e => e.Department)
                .FirstOrDefault();
            return View(easay);
        }

        [HttpPost]
        public IActionResult SelectedQuestion(int currentQuestionId)
        {

            // Check if the previous question exists in the database
            var nextQuestion = db.Questions
               .Include(q => q.Exam)
               .ThenInclude(eq => eq.Course)
               .ThenInclude(eq => eq.Department)
               .Include(q => q.Exam.EasayQuestions)
               .ThenInclude(eq => eq.SubEasayQuestions)
                .FirstOrDefault(q => q.Id == currentQuestionId);

            ViewBag.TotalQuestion = db.Questions.Count();
            if (nextQuestion != null)
            {
                // Return the partial view for Ajax request
                return PartialView("_QuestionPartial", nextQuestion);
            }
            else
            {
                // Handle the case when there is no previous question
                return Content("Start of the exam");
            }
        }                  

        [HttpPost]
        public IActionResult MoveToNextQuestion(int currentQuestionId)
        {
            var nextQuestionId = currentQuestionId + 1;

            ViewBag.TotalQuestion = db.Questions.Count();
            // Check if the previous question exists in the database
            var nextQuestion = db.Questions
               .Include(q => q.Exam)
               .ThenInclude(eq => eq.Course)
               .ThenInclude(eq => eq.Department)
               .Include(q => q.Exam.EasayQuestions)
               .ThenInclude(eq => eq.SubEasayQuestions)
                .FirstOrDefault(q => q.Id == nextQuestionId);

            if (nextQuestion != null)
            {
                // Return the partial view for Ajax request
                return PartialView("_QuestionPartial", nextQuestion);
            }
            else
            {
                // Handle the case when there is no previous question
                return Content("Start of the exam");
            }
        }

        //public IActionResult MoveToNextQuestion(int currentQuestionId)
        //{
        //    // Retrieve the previous question ID (assuming sequential IDs)
        //    //var nextQuestionId = currentQuestionId + 1;

        //    //var disabled = "";
        //    var totalQuestion = db.Questions.Max(x => x.Id);
        //    var nextQuestion = GetNextQuestion(currentQuestionId);

        //    if (nextQuestion != null)
        //    {
        //        if (nextQuestion is EasayQuestion)
        //        {
        //            return PartialView("_EssayQuestionPartial", nextQuestion);
        //        }
        //        else
        //        {
        //            return PartialView("_QuestionPartial", nextQuestion);
        //        }
        //    }
        //    else
        //    {
        //        // Handle the case when there is no next question
        //        return Content("End of the exam");
        //    }
        //    //if (nextQuestionId == totalQuestion)
        //    //{
        //    //    disabled = "disabled";
        //    //}
        //    //else
        //    //{
        //    //    disabled = "";
        //    //}

        //    //ViewBag.DisabledButton = disabled;
        //    //// Check if the previous question exists in the database
        //    //var nextQuestion = db.Questions
        //    //   .Include(q => q.Exam)
        //    //   .Include(q => q.Exam.EasayQuestions)
        //    //   .ThenInclude(eq => eq.SubEasayQuestions)
        //    //    .FirstOrDefault(q => q.Id == nextQuestionId);

        //    //if (nextQuestion != null)
        //    //{
        //    //    // Return the partial view for Ajax request
        //    //    return PartialView("_QuestionPartial", nextQuestion);
        //    //}
        //    //else
        //    //{
        //    //    // Handle the case when there is no previous question
        //    //    return Content("Start of the exam");
        //    //}
        //}

        //private Question GetNextQuestion(int currentQuestionId)
        //{
        //    // Retrieve the next question ID (assuming sequential IDs)
        //    var nextQuestionId = currentQuestionId + 1;

        //    // Check if the next question exists in the database
        //    var nextQuestion = db.Questions
        //        .Include(q => q.Exam)
        //        .Include(q => q.Exam.EasayQuestions)
        //        .ThenInclude(eq => eq.SubEasayQuestions)
        //        .FirstOrDefault(q => q.Id == nextQuestionId);

        //    // If the next question doesn't exist in Questions, check if there is an Essay question
        //    if (nextQuestion == null)
        //    {
        //        var nextEssayQuestion = db.EasayQuestion
        //            .Include(eq => eq.SubEasayQuestions)
        //            .FirstOrDefault(eq => eq.Id == eq.qu);

        //        if (nextEssayQuestion != null)
        //        {
        //            return nextEssayQuestion; // Return the next Essay question
        //        }
        //        else
        //        {
        //            // Check if the next question is in SubEasayQuestions
        //            var nextSubEasayQuestion = db.SubEasayQuestion
        //                .Include(seq => seq.EasayQuestion)
        //                .FirstOrDefault(/*seq => seq.EasayQuestion.ExamId == currentQuestion.ExamId &&*/ seq.Id == seq.EasayQuestionId);

        //            return nextSubEasayQuestion?.EasayQuestion; // Return the corresponding Essay question
        //        }
        //    }

        //    return nextQuestion; // Return the next Multiple Choice question
        //}


        [HttpPost]
        public IActionResult MoveToPreviousQuestion(int currentQuestionId)
        {
            // Retrieve the previous question ID (assuming sequential IDs)
            var previousQuestionId = currentQuestionId - 1;

            ViewBag.TotalQuestion = db.Questions.Count();
            // Check if the previous question exists in the database
            var previousQuestion = db.Questions
               .Include(q => q.Exam)
               .ThenInclude(eq => eq.Course)
               .ThenInclude(eq => eq.Department)
               .Include(q => q.Exam.EasayQuestions)
               .ThenInclude(eq => eq.SubEasayQuestions)
                .FirstOrDefault(q => q.Id == previousQuestionId);

            if (previousQuestion != null)
            {
                // Return the partial view for Ajax request
                return PartialView("_QuestionPartial", previousQuestion);
            }
            else
            {
                // Handle the case when there is no previous question
                return Content("Start of the exam");
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
