using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryAssessment.Data;
using LibraryAssessment.Models;

namespace LibraryAssessment.Controllers
{
    public class RentedController : Controller
    {
        private readonly AssessmentDbContext _context;

        public RentedController(AssessmentDbContext context)
        {
            _context = context;
        }

        // GET: Rented
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rented.ToListAsync());
        }

        // GET: Rented/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rented = await _context.Rented
                .FirstOrDefaultAsync(m => m.RId == id);
            if (rented == null)
            {
                return NotFound();
            }

            return View(rented);
        }

        // GET: Rented/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rented/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RId,DeleteMe")] Rented rented)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rented);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rented);
        }

        // GET: Rented/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rented = await _context.Rented.FindAsync(id);
            if (rented == null)
            {
                return NotFound();
            }
            return View(rented);
        }

        // POST: Rented/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RId,DeleteMe")] Rented rented)
        {
            if (id != rented.RId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rented);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentedExists(rented.RId))
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
            return View(rented);
        }

        // GET: Rented/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rented = await _context.Rented
                .FirstOrDefaultAsync(m => m.RId == id);
            if (rented == null)
            {
                return NotFound();
            }

            return View(rented);
        }

        // POST: Rented/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rented = await _context.Rented.FindAsync(id);
            _context.Rented.Remove(rented);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentedExists(int id)
        {
            return _context.Rented.Any(e => e.RId == id);
        }
    }
}
