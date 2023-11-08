using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livraria.Models;

namespace Livraria.Controllers
{
    public class AlertController : Controller
    {
        private readonly MyDbContext _context;

        public AlertController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Alerts
        public async Task<IActionResult> Index()
        {
            var alerts = await _context.Alert.ToListAsync();
            return View(alerts);
        }

        // GET: Alerts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alert = await _context.Alert
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alert == null)
            {
                return NotFound();
            }

            return View(alert);
        }

        // GET: Alerts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alerts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Issuedate, Bookname, Returndate, Fine")] Alert alert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alert);
        }

        // GET: Alerts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alert = await _context.Alert.FindAsync(id);
            if (alert == null)
            {
                return NotFound();
            }
            return View(alert);
        }

        // POST: Alerts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Issuedate, Bookname, Returndate, Fine")] Alert alert)
        {
            if (id != alert.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlertExists(alert.Id))
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
            return View(alert);
        }

        // GET: Alerts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alert = await _context.Alert
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alert == null)
            {
                return NotFound();
            }

            return View(alert);
        }

        // POST: Alerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alert = await _context.Alert.FindAsync(id);
            _context.Alert.Remove(alert);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index);
        }

        // Método FineCall
        public IActionResult FineCall(int id)
        {
            // Implemente a lógica para calcular a multa com base nas informações do alerta
            // e retorne os resultados apropriados.
            return View();
        }

        // Método ViewAlert
        public IActionResult ViewAlert(int id)
        {
            // Implemente a lógica para exibir o alerta ao usuário
            return View();
        }

        // Método SendToLibrarian
        public IActionResult SendToLibrarian(int id)
        {
            // Implemente a lógica para enviar o alerta para o bibliotecário
            return View();
        }

        // Método DeleteAlertByNo
        public IActionResult DeleteAlertByNo(int id)
        {
            // Implemente a lógica para excluir o alerta com base no número de identificação
            return View();
        }

        private bool AlertExists(int id)
        {
            return _context.Alert.Any(e => e.Id == id);
        }
    }
}
