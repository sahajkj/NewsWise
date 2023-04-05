using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewsWise.Models;

namespace NewsWise.Controllers
{
    public class ReviewPublishersController : Controller
    {
        private readonly NewswiseDbContext _context;

        public ReviewPublishersController(NewswiseDbContext context)
        {
            _context = context;
        }

        // GET: ReviewPublishers
        public async Task<IActionResult> Index()
        {
              return _context.ReviewPublisher != null ? 
                          View(await _context.ReviewPublisher.ToListAsync()) :
                          Problem("Entity set 'NewswiseDbContext.ReviewPublisher'  is null.");
        }

        // GET: ReviewPublishers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReviewPublisher == null)
            {
                return NotFound();
            }

            var reviewPublisher = await _context.ReviewPublisher
                .FirstOrDefaultAsync(m => m.ReviewPublisherId == id);
            if (reviewPublisher == null)
            {
                return NotFound();
            }

            return View(reviewPublisher);
        }

        // GET: ReviewPublishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReviewPublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewPublisherId,Publisher,Site")] ReviewPublisher reviewPublisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewPublisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reviewPublisher);
        }

        // GET: ReviewPublishers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReviewPublisher == null)
            {
                return NotFound();
            }

            var reviewPublisher = await _context.ReviewPublisher.FindAsync(id);
            if (reviewPublisher == null)
            {
                return NotFound();
            }
            return View(reviewPublisher);
        }

        // POST: ReviewPublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewPublisherId,Publisher,Site")] ReviewPublisher reviewPublisher)
        {
            if (id != reviewPublisher.ReviewPublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewPublisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewPublisherExists(reviewPublisher.ReviewPublisherId))
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
            return View(reviewPublisher);
        }

        // GET: ReviewPublishers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReviewPublisher == null)
            {
                return NotFound();
            }

            var reviewPublisher = await _context.ReviewPublisher
                .FirstOrDefaultAsync(m => m.ReviewPublisherId == id);
            if (reviewPublisher == null)
            {
                return NotFound();
            }

            return View(reviewPublisher);
        }

        // POST: ReviewPublishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReviewPublisher == null)
            {
                return Problem("Entity set 'NewswiseDbContext.ReviewPublisher'  is null.");
            }
            var reviewPublisher = await _context.ReviewPublisher.FindAsync(id);
            if (reviewPublisher != null)
            {
                _context.ReviewPublisher.Remove(reviewPublisher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewPublisherExists(int id)
        {
          return (_context.ReviewPublisher?.Any(e => e.ReviewPublisherId == id)).GetValueOrDefault();
        }
    }
}
