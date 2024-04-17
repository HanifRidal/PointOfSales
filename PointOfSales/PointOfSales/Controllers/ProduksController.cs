using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PointOfSales.Data;
using PointOfSales.Models.Domain;

namespace PointOfSales.Controllers
{
    public class ProduksController : Controller
    {
        private readonly AppDbContext _context;

        public ProduksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Produks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Produks.Include(p => p.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Produks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Produks == null)
            {
                return NotFound();
            }

            var produk = await _context.Produks
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProdukId == id);
            if (produk == null)
            {
                return NotFound();
            }

            return View(produk);
        }

        // GET: Produks/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Produks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdukId,Name,Description,Price,CategoryId")] Produk produk)
        {
            if (ModelState.IsValid)
            {
                produk.ProdukId = Guid.NewGuid();
                _context.Add(produk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", produk.CategoryId);
            return View(produk);
        }

        // GET: Produks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Produks == null)
            {
                return NotFound();
            }

            var produk = await _context.Produks.FindAsync(id);
            if (produk == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", produk.CategoryId);
            return View(produk);
        }

        // POST: Produks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProdukId,Name,Description,Price,CategoryId")] Produk produk)
        {
            if (id != produk.ProdukId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdukExists(produk.ProdukId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", produk.CategoryId);
            return View(produk);
        }

        // GET: Produks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Produks == null)
            {
                return NotFound();
            }

            var produk = await _context.Produks
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProdukId == id);
            if (produk == null)
            {
                return NotFound();
            }

            return View(produk);
        }

        // POST: Produks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Produks == null)
            {
                return Problem("Entity set 'AppDbContext.Produks'  is null.");
            }
            var produk = await _context.Produks.FindAsync(id);
            if (produk != null)
            {
                _context.Produks.Remove(produk);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdukExists(Guid id)
        {
          return (_context.Produks?.Any(e => e.ProdukId == id)).GetValueOrDefault();
        }
    }
}
