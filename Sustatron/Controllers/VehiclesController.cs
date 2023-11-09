using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Sustatron.Data;
using Sustatron.Models;
using static Sustatron.Models.Chart;

namespace Sustatron.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vehicles.Include(v => v.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "StudentNumber");
            return View();
        }


         // POST: Vehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleName,LicencePlate,MaxEmission,CurrentEmission,UserId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                // Calculate MaxEmission based on CurrentEmission
                vehicle.MaxEmission = 95 * 16 * 16; // 95g/km * 16km * 16 days retour trip 67rplg
                vehicle.CurrentEmission = 0;

                // Add the vehicle to the context
                _context.Add(vehicle);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", vehicle.UserId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleName,LicencePlate,MaxEmission,CurrentEmission,UserId")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", vehicle.UserId);
            return View(vehicle);
        }


		// GET: Vehicles/Chart/5
		public async Task<IActionResult> Chart(int? id)
		{
			if (id == null || _context.Vehicles == null)
			{
				return NotFound();
			}

			var vehicle = await _context.Vehicles
				.Include(v => v.User)
				.FirstOrDefaultAsync(m => m.Id == id);

			List<DataPoint> dataPoints = new List<DataPoint>();

			dataPoints.Add(new DataPoint("Max emission", vehicle.MaxEmission));
			dataPoints.Add(new DataPoint(vehicle.VehicleName, vehicle.CurrentEmission));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", vehicle.UserId);
			return View(vehicle);
		}

		// GET: Vehicles/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Vehicles == null)
			{
				return NotFound();
			}

			var vehicle = await _context.Vehicles.FindAsync(id);
			if (vehicle == null)
			{
				return NotFound();
			}
			ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", vehicle.UserId);
			return View(vehicle);
		}

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehicles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vehicles'  is null.");
            }
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
          return (_context.Vehicles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private async Task UpdateUserPoints(int userId, double percentageUsed)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                // Define your constants for point calculation
                const int MaxPoints = 100;        // Adjust the maximum points as needed
                const double PenaltyPoints = 2.0; // Adjust the penalty factor as needed

                // Calculate points based on the formula
                double points = MaxPoints - (percentageUsed * PenaltyPoints);

                // Ensure points are not negative
                if (points < 0)
                {
                    points = 0;
                }

                // Update the user's points add them to the old points
                user.Points = (int)points + user.Points;
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
        }
        // GET: Vehicles/UpdateEndOfMonth
        public async Task<IActionResult> UpdateEndOfMonth()
        {
            // Assuming the end of the month operation here
            // Loop through all vehicles

            var vehicles = await _context.Vehicles.Include(v => v.User).ToListAsync();

            foreach (var vehicle in vehicles)
            {
                // Calculate the percentage of max emission used
                double percentageUsed = (double)vehicle.CurrentEmission / vehicle.MaxEmission;

                // Update user points
                await UpdateUserPoints(vehicle.UserId, percentageUsed);

                // Set CurrentEmission to 0
                vehicle.CurrentEmission = 0;
                _context.Update(vehicle);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
