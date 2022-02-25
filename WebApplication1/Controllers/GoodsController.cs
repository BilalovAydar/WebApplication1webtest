using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GoodsController : Controller
    {
        private readonly WebApplication1Context _context;

        public GoodsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Goods
        
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null) return View(await _context.Good.Include(g => g.Price).ToListAsync());
            var webApplication1Context = _context.Good.Include(g => g.Price).Where(m=>m.PriceId == id);
            if (webApplication1Context == null) return NotFound();
            return View(await webApplication1Context.ToListAsync()); 
        }

        // GET: Goods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Good
                .Include(g => g.Price)
                .FirstOrDefaultAsync(m => m.GoodId == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // GET: Goods/Create
        public IActionResult Create()
        {
            ViewData["PriceId"] = new SelectList(_context.Price, "PriceId", "PriceId");
            return View();
        }

        // POST: Goods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoodId,PriceId,MyIntCol,MyStrCol,MyTextCol")] Good good)
        {
            if (ModelState.IsValid)
            {
                _context.Add(good);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PriceId"] = new SelectList(_context.Price, "PriceId", "PriceId", good.PriceId);
            return View(good);
        }

        // GET: Goods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Good.FindAsync(id);
            if (good == null)
            {
                return NotFound();
            }
            ViewData["PriceId"] = new SelectList(_context.Price, "PriceId", "PriceId", good.PriceId);
            return View(good);
        }

        // POST: Goods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GoodId,PriceId,MyIntCol,MyStrCol,MyTextCol")] Good good)
        {
            if (id != good.GoodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(good);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodExists(good.GoodId))
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
            ViewData["PriceId"] = new SelectList(_context.Price, "PriceId", "PriceId", good.PriceId);
            return View(good);
        }

        // GET: Goods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Good
                .Include(g => g.Price)
                .FirstOrDefaultAsync(m => m.GoodId == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var good = await _context.Good.FindAsync(id);
            _context.Good.Remove(good);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodExists(int id)
        {
            return _context.Good.Any(e => e.GoodId == id);
        }
    }
}
