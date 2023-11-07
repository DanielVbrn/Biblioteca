#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Livraria.Models;

namespace Livraria.Controllers
{
    public class LibraiansController : Controller
    {
        private readonly MyDbContext _context;

        public LibraiansController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Libraians
        public async Task<IActionResult> Index()
        {
            return View(await _context.Libraian.ToListAsync());
        }

        // GET: Libraians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraian = await _context.Libraian
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libraian == null)
            {
                return NotFound();
            }

            return View(libraian);
        }

        // GET: Libraians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libraians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,MobileNo")] Libraian libraian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libraian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libraian);
        }

        // GET: Libraians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraian = await _context.Libraian.FindAsync(id);
            if (libraian == null)
            {
                return NotFound();
            }
            return View(libraian);
        }

        // POST: Libraians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,MobileNo")] Libraian libraian)
        {
            if (id != libraian.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libraian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraianExists(libraian.Id))
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
            return View(libraian);
        }

        // GET: Libraians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraian = await _context.Libraian
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libraian == null)
            {
                return NotFound();
            }

            return View(libraian);
        }

        // POST: Libraians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libraian = await _context.Libraian.FindAsync(id);
            _context.Libraian.Remove(libraian);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraianExists(int id)
        {
            return _context.Libraian.Any(e => e.Id == id);
        }
    }
}
