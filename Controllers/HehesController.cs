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
    public class HehesController : Controller
    {
        private readonly MVCDBContext _context;

        public HehesController(MVCDBContext context)
        {
            _context = context;
        }

        // GET: Hehes
        public async Task<IActionResult> Index()
        {
            var mVCDBContext = _context.Hehe.Include(h => h.Haha);
            return View(await mVCDBContext.ToListAsync());
        }

        // GET: Hehes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hehe = await _context.Hehe
                .Include(h => h.Haha)
                .FirstOrDefaultAsync(m => m.HeheID == id);
            if (hehe == null)
            {
                return NotFound();
            }

            return View(hehe);
        }

        // GET: Hehes/Create
        public IActionResult Create()
        {
            ViewData["HahaID"] = new SelectList(_context.Set<Haha>(), "HahaID", "HahaID");
            return View();
        }

        // POST: Hehes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HeheID,HeheName,HahaID")] Hehe hehe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hehe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HahaID"] = new SelectList(_context.Set<Haha>(), "HahaID", "HahaID", hehe.HahaID);
            return View(hehe);
        }

        // GET: Hehes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hehe = await _context.Hehe.FindAsync(id);
            if (hehe == null)
            {
                return NotFound();
            }
            ViewData["HahaID"] = new SelectList(_context.Set<Haha>(), "HahaID", "HahaID", hehe.HahaID);
            return View(hehe);
        }

        // POST: Hehes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HeheID,HeheName,HahaID")] Hehe hehe)
        {
            if (id != hehe.HeheID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hehe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeheExists(hehe.HeheID))
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
            ViewData["HahaID"] = new SelectList(_context.Set<Haha>(), "HahaID", "HahaID", hehe.HahaID);
            return View(hehe);
        }

        // GET: Hehes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hehe = await _context.Hehe
                .Include(h => h.Haha)
                .FirstOrDefaultAsync(m => m.HeheID == id);
            if (hehe == null)
            {
                return NotFound();
            }

            return View(hehe);
        }

        // POST: Hehes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hehe = await _context.Hehe.FindAsync(id);
            _context.Hehe.Remove(hehe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeheExists(int id)
        {
            return _context.Hehe.Any(e => e.HeheID == id);
        }
    }
}
