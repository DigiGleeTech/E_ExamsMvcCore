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
    public class SubEasayQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubEasayQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubEasayQuestions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubEasayQuestion.Include(s => s.EasayQuestion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SubEasayQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subEasayQuestion = await _context.SubEasayQuestion
                .Include(s => s.EasayQuestion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subEasayQuestion == null)
            {
                return NotFound();
            }

            return View(subEasayQuestion);
        }

        // GET: SubEasayQuestions/Create
        public IActionResult Create()
        {
            ViewData["EasayQuestionId"] = new SelectList(_context.EasayQuestion, "Id", "Id");
            return View();
        }

        // POST: SubEasayQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QuestionText,EasayQuestionId")] SubEasayQuestion subEasayQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subEasayQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EasayQuestionId"] = new SelectList(_context.EasayQuestion, "Id", "Id", subEasayQuestion.EasayQuestionId);
            return View(subEasayQuestion);
        }

        // GET: SubEasayQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subEasayQuestion = await _context.SubEasayQuestion.FindAsync(id);
            if (subEasayQuestion == null)
            {
                return NotFound();
            }
            ViewData["EasayQuestionId"] = new SelectList(_context.EasayQuestion, "Id", "Id", subEasayQuestion.EasayQuestionId);
            return View(subEasayQuestion);
        }

        // POST: SubEasayQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuestionText,EasayQuestionId")] SubEasayQuestion subEasayQuestion)
        {
            if (id != subEasayQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subEasayQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubEasayQuestionExists(subEasayQuestion.Id))
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
            ViewData["EasayQuestionId"] = new SelectList(_context.EasayQuestion, "Id", "Id", subEasayQuestion.EasayQuestionId);
            return View(subEasayQuestion);
        }

        // GET: SubEasayQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subEasayQuestion = await _context.SubEasayQuestion
                .Include(s => s.EasayQuestion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subEasayQuestion == null)
            {
                return NotFound();
            }

            return View(subEasayQuestion);
        }

        // POST: SubEasayQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subEasayQuestion = await _context.SubEasayQuestion.FindAsync(id);
            if (subEasayQuestion != null)
            {
                _context.SubEasayQuestion.Remove(subEasayQuestion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubEasayQuestionExists(int id)
        {
            return _context.SubEasayQuestion.Any(e => e.Id == id);
        }
    }
}
