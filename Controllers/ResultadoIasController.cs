using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprint2.Models;
using Sprint2.Persistence;

namespace Sprint2.Controllers
{
    public class ResultadoIasController : Controller
    {
        private readonly OracleDbContext _context;

        public ResultadoIasController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: ResultadoIas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Resultados.ToListAsync());
        }

        // GET: ResultadoIas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultadoIa = await _context.Resultados
                .FirstOrDefaultAsync(m => m.Id_resultadoIa == id);
            if (resultadoIa == null)
            {
                return NotFound();
            }

            return View(resultadoIa);
        }

        // GET: ResultadoIas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResultadoIas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_resultadoIa,Tipo_analise,Detalhes")] ResultadoIa resultadoIa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultadoIa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resultadoIa);
        }

        // GET: ResultadoIas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultadoIa = await _context.Resultados.FindAsync(id);
            if (resultadoIa == null)
            {
                return NotFound();
            }
            return View(resultadoIa);
        }

        // POST: ResultadoIas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_resultadoIa,Tipo_analise,Detalhes")] ResultadoIa resultadoIa)
        {
            if (id != resultadoIa.Id_resultadoIa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultadoIa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultadoIaExists(resultadoIa.Id_resultadoIa))
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
            return View(resultadoIa);
        }

        // GET: ResultadoIas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultadoIa = await _context.Resultados
                .FirstOrDefaultAsync(m => m.Id_resultadoIa == id);
            if (resultadoIa == null)
            {
                return NotFound();
            }

            return View(resultadoIa);
        }

        // POST: ResultadoIas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultadoIa = await _context.Resultados.FindAsync(id);
            if (resultadoIa != null)
            {
                _context.Resultados.Remove(resultadoIa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultadoIaExists(int id)
        {
            return _context.Resultados.Any(e => e.Id_resultadoIa == id);
        }
    }
}
