using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sustatron.Data;
using Sustatron.Models;

namespace Sustatron.Controllers
{
    public class CommuteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommuteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Commute
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Commutes.Include(c => c.TransportationOption).Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Commute/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Commutes == null)
            {
                return NotFound();
            }

            var commute = await _context.Commutes
                .Include(c => c.TransportationOption)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commute == null)
            {
                return NotFound();
            }

            return View(commute);
        }

        // GET: Commute/Create
        public IActionResult Create()
        {
            ViewData["TransportationOptionId"] = new SelectList(_context.TransportationOptions, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Commute/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TransportationOptionId,Date,StartLocation,EndLocation,Distance,Duration,CarbonEmissions")] Commute commute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TransportationOptionId"] = new SelectList(_context.TransportationOptions, "Id", "Id", commute.TransportationOptionId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", commute.UserId);
            return View(commute);
        }

        // GET: Commute/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Commutes == null)
            {
                return NotFound();
            }

            var commute = await _context.Commutes.FindAsync(id);
            if (commute == null)
            {
                return NotFound();
            }
            ViewData["TransportationOptionId"] = new SelectList(_context.TransportationOptions, "Id", "Id", commute.TransportationOptionId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", commute.UserId);
            return View(commute);
        }

        // POST: Commute/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TransportationOptionId,Date,StartLocation,EndLocation,Distance,Duration,CarbonEmissions")] Commute commute)
        {
            if (id != commute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommuteExists(commute.Id))
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
            ViewData["TransportationOptionId"] = new SelectList(_context.TransportationOptions, "Id", "Id", commute.TransportationOptionId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", commute.UserId);
            return View(commute);
        }

        // GET: Commute/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Commutes == null)
            {
                return NotFound();
            }

            var commute = await _context.Commutes
                .Include(c => c.TransportationOption)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commute == null)
            {
                return NotFound();
            }

            return View(commute);
        }

        // POST: Commute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Commutes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Commutes'  is null.");
            }
            var commute = await _context.Commutes.FindAsync(id);
            if (commute != null)
            {
                _context.Commutes.Remove(commute);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommuteExists(int id)
        {
          return (_context.Commutes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
