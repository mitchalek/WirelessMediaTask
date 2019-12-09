using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WirelessMediaTask.Models;

namespace WirelessMediaTask.Controllers
{
    public class MakersController : Controller
    {
        private readonly ProductsContext _context;

        public MakersController(ProductsContext context)
        {
            _context = context;
        }

        // GET: Makers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Makers.ToListAsync());
        }

        // GET: Makers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maker = await _context.Makers
                .FirstOrDefaultAsync(m => m.MakerId == id);
            if (maker == null)
            {
                return NotFound();
            }

            return View(maker);
        }

        // GET: Makers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Makers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MakerId,Name")] Maker maker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maker);
        }

        // GET: Makers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maker = await _context.Makers.FindAsync(id);
            if (maker == null)
            {
                return NotFound();
            }
            return View(maker);
        }

        // POST: Makers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MakerId,Name")] Maker maker)
        {
            if (id != maker.MakerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakerExists(maker.MakerId))
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
            return View(maker);
        }

        // GET: Makers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maker = await _context.Makers
                .FirstOrDefaultAsync(m => m.MakerId == id);
            if (maker == null)
            {
                return NotFound();
            }

            return View(maker);
        }

        // POST: Makers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maker = await _context.Makers.FindAsync(id);
            _context.Makers.Remove(maker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MakerExists(int id)
        {
            return _context.Makers.Any(e => e.MakerId == id);
        }
    }
}
