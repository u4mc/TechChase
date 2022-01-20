#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechChase.Data;
using TechChaser.Models;

namespace TechChase.Controllers
{
    public class TechController : Controller
    {
        private readonly TechChaseContext _context;

        public TechController(TechChaseContext context)
        {
            _context = context;
        }

        // GET: Tech
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tech.ToListAsync());
        }

        // GET: Tech/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tech = await _context.Tech
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tech == null)
            {
                return NotFound();
            }

            return View(tech);
        }

        // GET: Tech/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tech/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Character,Game,UserNotes,Link")] Tech tech)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tech);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tech);
        }

        // GET: Tech/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tech = await _context.Tech.FindAsync(id);
            if (tech == null)
            {
                return NotFound();
            }
            return View(tech);
        }

        // POST: Tech/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Character,Game,UserNotes,Link")] Tech tech)
        {
            if (id != tech.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tech);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechExists(tech.ID))
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
            return View(tech);
        }

        // GET: Tech/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tech = await _context.Tech
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tech == null)
            {
                return NotFound();
            }

            return View(tech);
        }

        // POST: Tech/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tech = await _context.Tech.FindAsync(id);
            _context.Tech.Remove(tech);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechExists(int id)
        {
            return _context.Tech.Any(e => e.ID == id);
        }
    }
}
