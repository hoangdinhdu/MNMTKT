using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo.Models;

namespace Demo.Controllers
{
    public class HahasController : Controller
    {
        private readonly MVCDBContext _context;

        public HahasController(MVCDBContext context)
        {
            _context = context;
        }

        // GET: Hahas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Haha.ToListAsync());
        }

        // GET: Hahas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haha = await _context.Haha
                .FirstOrDefaultAsync(m => m.HahaID == id);
            if (haha == null)
            {
                return NotFound();
            }

            return View(haha);
        }

        // GET: Hahas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hahas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HahaID,HahaName")] Haha haha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(haha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(haha);
        }

        // GET: Hahas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haha = await _context.Haha.FindAsync(id);
            if (haha == null)
            {
                return NotFound();
            }
            return View(haha);
        }

        // POST: Hahas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HahaID,HahaName")] Haha haha)
        {
            if (id != haha.HahaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(haha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HahaExists(haha.HahaID))
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
            return View(haha);
        }

        // GET: Hahas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haha = await _context.Haha
                .FirstOrDefaultAsync(m => m.HahaID == id);
            if (haha == null)
            {
                return NotFound();
            }

            return View(haha);
        }

        // POST: Hahas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var haha = await _context.Haha.FindAsync(id);
            _context.Haha.Remove(haha);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HahaExists(string id)
        {
            return _context.Haha.Any(e => e.HahaID == id);
        }
    }
}
