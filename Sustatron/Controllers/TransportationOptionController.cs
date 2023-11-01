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
    public class TransportationOptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportationOptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TransportationOption
        public async Task<IActionResult> Index()
        {
              return _context.TransportationOptions != null ? 
                          View(await _context.TransportationOptions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TransportationOptions'  is null.");
        }

        // GET: TransportationOption/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransportationOptions == null)
            {
                return NotFound();
            }

            var transportationOption = await _context.TransportationOptions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportationOption == null)
            {
                return NotFound();
            }

            return View(transportationOption);
        }

        // GET: TransportationOption/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransportationOption/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,optionName,description,icon")] TransportationOption transportationOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportationOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transportationOption);
        }

        // GET: TransportationOption/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransportationOptions == null)
            {
                return NotFound();
            }

            var transportationOption = await _context.TransportationOptions.FindAsync(id);
            if (transportationOption == null)
            {
                return NotFound();
            }
            return View(transportationOption);
        }

        // POST: TransportationOption/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,optionName,description,icon")] TransportationOption transportationOption)
        {
            if (id != transportationOption.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportationOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportationOptionExists(transportationOption.Id))
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
            return View(transportationOption);
        }

        // GET: TransportationOption/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransportationOptions == null)
            {
                return NotFound();
            }

            var transportationOption = await _context.TransportationOptions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportationOption == null)
            {
                return NotFound();
            }

            return View(transportationOption);
        }

        // POST: TransportationOption/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransportationOptions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TransportationOptions'  is null.");
            }
            var transportationOption = await _context.TransportationOptions.FindAsync(id);
            if (transportationOption != null)
            {
                _context.TransportationOptions.Remove(transportationOption);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportationOptionExists(int id)
        {
          return (_context.TransportationOptions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
