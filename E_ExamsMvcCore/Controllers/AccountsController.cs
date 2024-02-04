using E_ExamsMvcCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using E_ExamsMvcCore.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_ExamsMvcCore.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserStore<IdentityUser> userStore;
        private readonly ApplicationDbContext db;
        private readonly IUserEmailStore<IdentityUser> emailStore;
        public AccountsController(
            UserManager<IdentityUser> userManager, 
            IUserStore<IdentityUser> userStore, 
            IEmailSender emailSender,
            ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.userStore = userStore;
            this.db = db;
            emailStore = GetEmailStore();
        }

        // GET: AccountsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Accounts/RegisterCandidate
        [HttpGet]
        public IActionResult RegisterCandidate()
        {
            ViewData["DepartmentId"] = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCandidate(Candidate candidate)
        {
            var msg = "";

            if (ModelState.IsValid)
            {
                await userStore.SetUserNameAsync(candidate, candidate.Email, CancellationToken.None);
                await emailStore.SetEmailAsync(candidate, candidate.Email, CancellationToken.None);

                var username = await userManager.FindByNameAsync(candidate.Email);
                if (username != null )
                {
                    var UsernameErrorMsg = candidate.Email;
                    ViewBag.Message = UsernameErrorMsg;

                    return View();
                }

                var result = await userManager.CreateAsync(candidate, candidate.Password);

                if (result.Succeeded)
                {
                    var resul = await userManager.AddToRoleAsync(candidate, WC.CandidatenRole);
                    
                    if (resul.Succeeded)
                    {
                        // User successfully added to the role
                        //return Ok("User added to role successfully");
                        msg = "User added to role successfully";
                        return View();
                    }
                    else
                    {
                        msg = "User was not added to role";
                    }
                }

                ViewBag.Message = msg;

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        
            
            return View();
        }

        // GET: AccountsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)userStore;
        }


    }
}
