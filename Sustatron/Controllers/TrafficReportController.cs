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
    public class TrafficReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrafficReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrafficReport
        public async Task<IActionResult> Index()
        {
              return _context.TrafficReports != null ? 
                          View(await _context.TrafficReports.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TrafficReports'  is null.");
        }

        // GET: TrafficReport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TrafficReports == null)
            {
                return NotFound();
            }

            var trafficReport = await _context.TrafficReports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trafficReport == null)
            {
                return NotFound();
            }

            return View(trafficReport);
        }

        // GET: TrafficReport/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrafficReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,TrafficConditions,Source")] TrafficReport trafficReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trafficReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trafficReport);
        }

        // GET: TrafficReport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TrafficReports == null)
            {
                return NotFound();
            }

            var trafficReport = await _context.TrafficReports.FindAsync(id);
            if (trafficReport == null)
            {
                return NotFound();
            }
            return View(trafficReport);
        }

        // POST: TrafficReport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,TrafficConditions,Source")] TrafficReport trafficReport)
        {
            if (id != trafficReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trafficReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrafficReportExists(trafficReport.Id))
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
            return View(trafficReport);
        }

        // GET: TrafficReport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TrafficReports == null)
            {
                return NotFound();
            }

            var trafficReport = await _context.TrafficReports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trafficReport == null)
            {
                return NotFound();
            }

            return View(trafficReport);
        }

        // POST: TrafficReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TrafficReports == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TrafficReports'  is null.");
            }
            var trafficReport = await _context.TrafficReports.FindAsync(id);
            if (trafficReport != null)
            {
                _context.TrafficReports.Remove(trafficReport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrafficReportExists(int id)
        {
          return (_context.TrafficReports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
