using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_ExamsMvcCore.Data;
using E_ExamsMvcCore.Models;

namespace E_ExamsMvcCore.Controllers
{
    public class EasayQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EasayQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EasayQuestions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EasayQuestion
                .Include(e => e.Exam);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EasayQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var easayQuestion = await _context.EasayQuestion
                .Include(e => e.Exam)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (easayQuestion == null)
            {
                return NotFound();
            }

            return View(easayQuestion);
        }

        // GET: EasayQuestions/Create
        public IActionResult Create()
        {
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Title");
            return View();
        }

        // POST: EasayQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Instruction,QuestionContent,ExamId")] EasayQuestion easayQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(easayQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Title", easayQuestion.ExamId);
            return View(easayQuestion);
        }

        // GET: EasayQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var easayQuestion = await _context.EasayQuestion.FindAsync(id);
            if (easayQuestion == null)
            {
                return NotFound();
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id", easayQuestion.ExamId);
            return View(easayQuestion);
        }

        // POST: EasayQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Instruction,QuestionContent,ExamId")] EasayQuestion easayQuestion)
        {
            if (id != easayQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(easayQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EasayQuestionExists(easayQuestion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id", easayQuestion.ExamId);
            return View(easayQuestion);
        }

        // GET: EasayQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var easayQuestion = await _context.EasayQuestion
                .Include(e => e.Exam)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (easayQuestion == null)
            {
                return NotFound();
            }

            return View(easayQuestion);
        }

        // POST: EasayQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var easayQuestion = await _context.EasayQuestion.FindAsync(id);
            if (easayQuestion != null)
            {
                _context.EasayQuestion.Remove(easayQuestion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EasayQuestionExists(int id)
        {
            return _context.EasayQuestion.Any(e => e.Id == id);
        }
    }
}
