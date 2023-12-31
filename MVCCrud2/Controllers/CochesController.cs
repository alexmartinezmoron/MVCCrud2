﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCrud2;
using MVCCrud2.Models;

namespace MVCCrud2.Controllers
{
    public class CochesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CochesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Coches
        public async Task<IActionResult> Index()
        {
              return _context.Coches != null ? 
                          View(await _context.Coches.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Coches'  is null.");
        }

        // GET: Coches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Coches == null)
            {
                return NotFound();
            }

            var coche = await _context.Coches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coche == null)
            {
                return NotFound();
            }

            return View(coche);
        }

        // GET: Coches/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add(int originPointId = 0)
        {
            Coche model = new Coche();
            Marca marca = new Marca();
                    

            return View(model.marca);
        }



        //

        // POST: Coches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Matricula,Modelo,Color,MarcayId")] Coche coche)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coche);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coche);
        }

        // GET: Coches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Coches == null)
            {
                return NotFound();
            }

            var coche = await _context.Coches.FindAsync(id);
            if (coche == null)
            {
                return NotFound();
            }
            return View(coche);
        }

        // POST: Coches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Matricula,Modelo,Color,MarcayId")] Coche coche)
        {
            if (id != coche.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coche);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocheExists(coche.Id))
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
            return View(coche);
        }

        // GET: Coches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Coches == null)
            {
                return NotFound();
            }

            var coche = await _context.Coches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coche == null)
            {
                return NotFound();
            }

            return View(coche);
        }

        // POST: Coches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Coches == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Coches'  is null.");
            }
            var coche = await _context.Coches.FindAsync(id);
            if (coche != null)
            {
                _context.Coches.Remove(coche);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CocheExists(int id)
        {
          return (_context.Coches?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
