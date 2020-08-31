using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using postest.Models;

namespace postest.Controllers
{
    public class CatigoriesController : Controller
    {
        private readonly AppDbContext _context;

        public CatigoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Catigories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catigories.ToListAsync());
        }

        // GET: Catigories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catigories = await _context.Catigories
                .FirstOrDefaultAsync(m => m.CAT_ID == id);
            if (catigories == null)
            {
                return NotFound();
            }

            return View(catigories);
        }

        // GET: Catigories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catigories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CAT_ID,Desc")] Catigories catigories)
        {

            if (ModelState.IsValid)
            {
                _context.Add(catigories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catigories);
        }

        // GET: Catigories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catigories = await _context.Catigories.FindAsync(id);
            if (catigories == null)
            {
                return NotFound();
            }
            return View(catigories);
        }

        // POST: Catigories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CAT_ID,Desc")] Catigories catigories)
        {
            if (id != catigories.CAT_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catigories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatigoriesExists(catigories.CAT_ID))
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
            return View(catigories);
        }

        // GET: Catigories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catigories = await _context.Catigories
                .FirstOrDefaultAsync(m => m.CAT_ID == id);
            if (catigories == null)
            {
                return NotFound();
            }

            return View(catigories);
        }

        // POST: Catigories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catigories = await _context.Catigories.FindAsync(id);
            _context.Catigories.Remove(catigories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatigoriesExists(int id)
        {
            return _context.Catigories.Any(e => e.CAT_ID == id);
        }
    }
}
