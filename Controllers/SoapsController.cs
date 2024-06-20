﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoutiqueSoap.Data;
using BoutiqueSoap.Models;

namespace BoutiqueSoap.Controllers
{
    public class SoapsController : Controller
    {
        private readonly BoutiqueSoapContext _context;

        public SoapsController(BoutiqueSoapContext context)
        {
            _context = context;
        }

        // GET: Soaps
        public async Task<IActionResult> Index()
        {
              return _context.Soap != null ? 
                          View(await _context.Soap.ToListAsync()) :
                          Problem("Entity set 'BoutiqueSoapContext.Soap'  is null.");
        }

        // GET: Soaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Soap == null)
            {
                return NotFound();
            }

            var soap = await _context.Soap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soap == null)
            {
                return NotFound();
            }

            return View(soap);
        }

        // GET: Soaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Soaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Scent,Weight,Price,Description")] Soap soap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soap);
        }

        // GET: Soaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Soap == null)
            {
                return NotFound();
            }

            var soap = await _context.Soap.FindAsync(id);
            if (soap == null)
            {
                return NotFound();
            }
            return View(soap);
        }

        // POST: Soaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Scent,Weight,Price,Description")] Soap soap)
        {
            if (id != soap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoapExists(soap.Id))
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
            return View(soap);
        }

        // GET: Soaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Soap == null)
            {
                return NotFound();
            }

            var soap = await _context.Soap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soap == null)
            {
                return NotFound();
            }

            return View(soap);
        }

        // POST: Soaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Soap == null)
            {
                return Problem("Entity set 'BoutiqueSoapContext.Soap'  is null.");
            }
            var soap = await _context.Soap.FindAsync(id);
            if (soap != null)
            {
                _context.Soap.Remove(soap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoapExists(int id)
        {
          return (_context.Soap?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
