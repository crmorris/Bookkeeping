#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookkeeping.Models;
using Programs.Models;

namespace Programs.Controllers
{
    public class TemporariesController : Controller
    {
        private readonly BookkeepingContext _context;

        public TemporariesController(BookkeepingContext context)
        {
            _context = context;
        }

        // GET: Temporaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Temporary.ToListAsync());
        }

        // GET: Temporaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporary = await _context.Temporary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temporary == null)
            {
                return NotFound();
            }

            return View(temporary);
        }

        // GET: Temporaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Temporaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,Value")] Temporary temporary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temporary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(temporary);
        }

        // GET: Temporaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporary = await _context.Temporary.FindAsync(id);
            if (temporary == null)
            {
                return NotFound();
            }
            return View(temporary);
        }

        // POST: Temporaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,Value")] Temporary temporary)
        {
            if (id != temporary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temporary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemporaryExists(temporary.Id))
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
            return View(temporary);
        }

        // GET: Temporaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporary = await _context.Temporary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temporary == null)
            {
                return NotFound();
            }

            return View(temporary);
        }

        // POST: Temporaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temporary = await _context.Temporary.FindAsync(id);
            _context.Temporary.Remove(temporary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemporaryExists(int id)
        {
            return _context.Temporary.Any(e => e.Id == id);
        }
    }
}
