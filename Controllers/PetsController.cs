﻿using System;
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
    public class PetsController : Controller
    {
        private readonly Shelter2Context _context;

        public PetsController(Shelter2Context context)
        {
            _context = context;
        }

        // GET: Pets
        public async Task<IActionResult> Index(string PetsTypeOfInspection, string SearchString)
        {
            {
                if (_context.Pets == null)
                {
                    return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
                }
                IQueryable<string> typeQuery = from m in _context.Pets
                                                orderby m.TypeOfInspection
                                                select m.TypeOfInspection;

                var pets = _context.Pets.Include(v => v.Shelter).AsQueryable();

                if (!String.IsNullOrEmpty(SearchString))
                {
                    pets = pets.Where(s => s.Name!.ToUpper().Contains(SearchString.ToUpper()));
                }

                if (!string.IsNullOrEmpty(PetsTypeOfInspection))
                {
                    pets = pets.Where(x => x.TypeOfInspection == PetsTypeOfInspection);
                }

                var petsTypeVM = new PetsOperationViewModel
                {
                    TypeOfInspection = new SelectList(await typeQuery.Distinct().ToListAsync()),
                    Pets = await pets.ToListAsync()
                };

                return View(petsTypeVM);
            }
        }
        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pets = await _context.Pets
                .Include(v => v.Shelter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pets == null)
            {
                return NotFound();
            }

            return View(pets);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            ViewData["ShelterId"] = new SelectList(_context.Set<Shelter>(), "Id", "NameShelter");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date,TypeOfInspection,Price,ShelterId")] Pets pets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShelterId"] = new SelectList(_context.Set<Shelter>(), "Id", "NameShelter", pets.ShelterId);
            return View(pets);
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pets = await _context.Pets.FindAsync(id);
            if (pets == null)
            {
                return NotFound();
            }
            ViewData["ShelterId"] = new SelectList(_context.Set<Shelter>(), "Id", "NameShelter", pets.ShelterId);
            return View(pets);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date,TypeOfInspection,Price,Age,ShelterId")] Pets pets)
        {
            if (id != pets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetsExists(pets.Id))
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
            ViewData["ShelterId"] = new SelectList(_context.Set<Shelter>(), "Id", "NameShelter", pets.ShelterId);
            return View(pets);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pets = await _context.Pets
                .Include(v => v.Shelter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pets == null)
            {
                return NotFound();
            }

            return View(pets);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pets = await _context.Pets.FindAsync(id);
            if (pets != null)
            {
                _context.Pets.Remove(pets);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetsExists(int id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }
    }
}
