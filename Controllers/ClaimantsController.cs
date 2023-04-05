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
    public class ClaimantsController : Controller
    {
        private readonly NewswiseDbContext _context;

        public ClaimantsController(NewswiseDbContext context)
        {
            _context = context;
        }

        // GET: Claimants
        public async Task<IActionResult> Index()
        {
              return _context.Claimants != null ? 
                          View(await _context.Claimants.ToListAsync()) :
                          Problem("Entity set 'NewswiseDbContext.Claimants'  is null.");
        }

        // GET: Claimants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Claimants == null)
            {
                return NotFound();
            }

            var claimant = await _context.Claimants
                .FirstOrDefaultAsync(m => m.ClaimantId == id);
            if (claimant == null)
            {
                return NotFound();
            }

            return View(claimant);
        }

        // GET: Claimants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Claimants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClaimantId,ClaimantName")] Claimant claimant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(claimant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(claimant);
        }

        // GET: Claimants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Claimants == null)
            {
                return NotFound();
            }

            var claimant = await _context.Claimants.FindAsync(id);
            if (claimant == null)
            {
                return NotFound();
            }
            return View(claimant);
        }

        // POST: Claimants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClaimantId,ClaimantName")] Claimant claimant)
        {
            if (id != claimant.ClaimantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claimant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimantExists(claimant.ClaimantId))
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
            return View(claimant);
        }

        // GET: Claimants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Claimants == null)
            {
                return NotFound();
            }

            var claimant = await _context.Claimants
                .FirstOrDefaultAsync(m => m.ClaimantId == id);
            if (claimant == null)
            {
                return NotFound();
            }

            return View(claimant);
        }

        // POST: Claimants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Claimants == null)
            {
                return Problem("Entity set 'NewswiseDbContext.Claimants'  is null.");
            }
            var claimant = await _context.Claimants.FindAsync(id);
            if (claimant != null)
            {
                _context.Claimants.Remove(claimant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaimantExists(int id)
        {
          return (_context.Claimants?.Any(e => e.ClaimantId == id)).GetValueOrDefault();
        }
    }
}
