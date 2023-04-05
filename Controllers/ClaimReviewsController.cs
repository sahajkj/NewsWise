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
    public class ClaimReviewsController : Controller
    {
        private readonly NewswiseDbContext _context;

        public ClaimReviewsController(NewswiseDbContext context)
        {
            _context = context;
        }

        // GET: ClaimReviews
        public async Task<IActionResult> Index()
        {
              return _context.Review != null ? 
                          View(await _context.Review.ToListAsync()) :
                          Problem("Entity set 'NewswiseDbContext.Review'  is null.");
        }

        // GET: ClaimReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var claimReview = await _context.Review
                .FirstOrDefaultAsync(m => m.ClaimReviewId == id);
            if (claimReview == null)
            {
                return NotFound();
            }

            return View(claimReview);
        }

        // GET: ClaimReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClaimReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClaimReviewId,Title,Url,ReviewDate,TextualRating,ClaimId,ReviewPublisherId")] ClaimReview claimReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(claimReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(claimReview);
        }

        // GET: ClaimReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var claimReview = await _context.Review.FindAsync(id);
            if (claimReview == null)
            {
                return NotFound();
            }
            return View(claimReview);
        }

        // POST: ClaimReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClaimReviewId,Title,Url,ReviewDate,TextualRating,ClaimId,ReviewPublisherId")] ClaimReview claimReview)
        {
            if (id != claimReview.ClaimReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claimReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimReviewExists(claimReview.ClaimReviewId))
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
            return View(claimReview);
        }

        // GET: ClaimReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var claimReview = await _context.Review
                .FirstOrDefaultAsync(m => m.ClaimReviewId == id);
            if (claimReview == null)
            {
                return NotFound();
            }

            return View(claimReview);
        }

        // POST: ClaimReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Review == null)
            {
                return Problem("Entity set 'NewswiseDbContext.Review'  is null.");
            }
            var claimReview = await _context.Review.FindAsync(id);
            if (claimReview != null)
            {
                _context.Review.Remove(claimReview);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaimReviewExists(int id)
        {
          return (_context.Review?.Any(e => e.ClaimReviewId == id)).GetValueOrDefault();
        }
    }
}
