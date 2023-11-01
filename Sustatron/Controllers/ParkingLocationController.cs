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
    public class ParkingLocationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParkingLocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ParkingLocation
        public async Task<IActionResult> Index()
        {
              return _context.ParkingLocations != null ? 
                          View(await _context.ParkingLocations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ParkingLocations'  is null.");
        }

        // GET: ParkingLocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParkingLocations == null)
            {
                return NotFound();
            }

            var parkingLocation = await _context.ParkingLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingLocation == null)
            {
                return NotFound();
            }

            return View(parkingLocation);
        }

        // GET: ParkingLocation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkingLocation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,locationName,description,capacity,latitude,longitude")] ParkingLocation parkingLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingLocation);
        }

        // GET: ParkingLocation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParkingLocations == null)
            {
                return NotFound();
            }

            var parkingLocation = await _context.ParkingLocations.FindAsync(id);
            if (parkingLocation == null)
            {
                return NotFound();
            }
            return View(parkingLocation);
        }

        // POST: ParkingLocation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,locationName,description,capacity,latitude,longitude")] ParkingLocation parkingLocation)
        {
            if (id != parkingLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingLocationExists(parkingLocation.Id))
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
            return View(parkingLocation);
        }

        // GET: ParkingLocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParkingLocations == null)
            {
                return NotFound();
            }

            var parkingLocation = await _context.ParkingLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingLocation == null)
            {
                return NotFound();
            }

            return View(parkingLocation);
        }

        // POST: ParkingLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParkingLocations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ParkingLocations'  is null.");
            }
            var parkingLocation = await _context.ParkingLocations.FindAsync(id);
            if (parkingLocation != null)
            {
                _context.ParkingLocations.Remove(parkingLocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingLocationExists(int id)
        {
          return (_context.ParkingLocations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
