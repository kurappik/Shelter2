using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shelter2.Data;
using Shelter2.Models;

namespace Shelter2.Controllers
{
    public class VolonteersController : Controller
    {
        private readonly Shelter2Context _context;

        public VolonteersController(Shelter2Context context)
        {
            _context = context;
        }

        // GET: Volonteers
        public async Task<IActionResult> Index()
        {
            var shelter2Context = _context.Volonteer.Include(v => v.Shelter);
            return View(await shelter2Context.ToListAsync());
        }

        // GET: Volonteers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volonteer = await _context.Volonteer
                .Include(v => v.Shelter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volonteer == null)
            {
                return NotFound();
            }

            return View(volonteer);
        }

        // GET: Volonteers/Create
        public IActionResult Create()
        {
            ViewData["ShelterId"] = new SelectList(_context.Set<Shelter>(), "Id", "NameShelter");
            return View();
        }

        // POST: Volonteers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameVolonteer,DateVolonteer,StatusVolonteer,AgeVolonteer,PriceVolonteer,ShelterId")] Volonteer volonteer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(volonteer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShelterId"] = new SelectList(_context.Set<Shelter>(), "Id", "NameShelter", volonteer.ShelterId);
            return View(volonteer);
        }

        // GET: Volonteers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volonteer = await _context.Volonteer.FindAsync(id);
            if (volonteer == null)
            {
                return NotFound();
            }
            ViewData["ShelterId"] = new SelectList(_context.Set<Shelter>(), "Id", "NameShelter", volonteer.ShelterId);
            return View(volonteer);
        }

        // POST: Volonteers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameVolonteer,DateVolonteer,StatusVolonteer,AgeVolonteer,PriceVolonteer,ShelterId")] Volonteer volonteer)
        {
            if (id != volonteer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volonteer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolonteerExists(volonteer.Id))
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
            ViewData["ShelterId"] = new SelectList(_context.Set<Shelter>(), "Id", "NameShelter", volonteer.ShelterId);
            return View(volonteer);
        }

        // GET: Volonteers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volonteer = await _context.Volonteer
                .Include(v => v.Shelter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volonteer == null)
            {
                return NotFound();
            }

            return View(volonteer);
        }

        // POST: Volonteers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volonteer = await _context.Volonteer.FindAsync(id);
            if (volonteer != null)
            {
                _context.Volonteer.Remove(volonteer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolonteerExists(int id)
        {
            return _context.Volonteer.Any(e => e.Id == id);
        }
    }
}
