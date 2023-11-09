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
            var applicationDbContext = _context.Commutes.Include(c => c.Vehicle);
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
                .Include(c => c.Vehicle)
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "LicencePlate");
            return View();
        }

        // POST: Commute/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KmDistance,Date,VehicleId")] Commute commute)
        {
            if (ModelState.IsValid)
            {
                // Calculate the emission increase based on KmDistance
                double emissionIncrease = commute.KmDistance * 95;

                // Retrieve the corresponding vehicle from the database
                var vehicle = await _context.Vehicles.FindAsync(commute.VehicleId);

                if (vehicle != null)
                {
                    // Update the CurrentEmission in the vehicle
                    vehicle.CurrentEmission = (int)Math.Round(vehicle.CurrentEmission + emissionIncrease);

                    // Add the commute to the context
                    _context.Add(commute);

                    // Save changes to the database
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle the case where the vehicle is not found
                    ModelState.AddModelError(string.Empty, "Vehicle not found.");
                }
            }

            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", commute.VehicleId);
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", commute.VehicleId);
            return View(commute);
        }

        // POST: Commute/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KmDistance,Date,VehicleId")] Commute commute)
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", commute.VehicleId);
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
                .Include(c => c.Vehicle)
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
