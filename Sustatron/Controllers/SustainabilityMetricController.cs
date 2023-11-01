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
    public class SustainabilityMetricController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SustainabilityMetricController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SustainabilityMetric
        public async Task<IActionResult> Index()
        {
              return _context.SustainabilityMetrics != null ? 
                          View(await _context.SustainabilityMetrics.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SustainabilityMetrics'  is null.");
        }

        // GET: SustainabilityMetric/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SustainabilityMetrics == null)
            {
                return NotFound();
            }

            var sustainabilityMetric = await _context.SustainabilityMetrics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sustainabilityMetric == null)
            {
                return NotFound();
            }

            return View(sustainabilityMetric);
        }

        // GET: SustainabilityMetric/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SustainabilityMetric/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,metricName,description,unit")] SustainabilityMetric sustainabilityMetric)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sustainabilityMetric);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sustainabilityMetric);
        }

        // GET: SustainabilityMetric/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SustainabilityMetrics == null)
            {
                return NotFound();
            }

            var sustainabilityMetric = await _context.SustainabilityMetrics.FindAsync(id);
            if (sustainabilityMetric == null)
            {
                return NotFound();
            }
            return View(sustainabilityMetric);
        }

        // POST: SustainabilityMetric/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,metricName,description,unit")] SustainabilityMetric sustainabilityMetric)
        {
            if (id != sustainabilityMetric.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sustainabilityMetric);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SustainabilityMetricExists(sustainabilityMetric.Id))
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
            return View(sustainabilityMetric);
        }

        // GET: SustainabilityMetric/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SustainabilityMetrics == null)
            {
                return NotFound();
            }

            var sustainabilityMetric = await _context.SustainabilityMetrics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sustainabilityMetric == null)
            {
                return NotFound();
            }

            return View(sustainabilityMetric);
        }

        // POST: SustainabilityMetric/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SustainabilityMetrics == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SustainabilityMetrics'  is null.");
            }
            var sustainabilityMetric = await _context.SustainabilityMetrics.FindAsync(id);
            if (sustainabilityMetric != null)
            {
                _context.SustainabilityMetrics.Remove(sustainabilityMetric);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SustainabilityMetricExists(int id)
        {
          return (_context.SustainabilityMetrics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
