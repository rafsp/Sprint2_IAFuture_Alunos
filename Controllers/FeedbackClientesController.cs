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
    public class FeedbackClientesController : Controller
    {
        private readonly OracleDbContext _context;

        public FeedbackClientesController(OracleDbContext context)
        {
            _context = context;
        }


        // GET: FeedbackClientes
        public async Task<IActionResult> Index()
        {
            var feedbacks = await _context.Feedbacks
                                            .Include(f => f.Cliente) // Carrega os dados do Cliente
                                            .ToListAsync();
            return View(feedbacks);
        }

        // GET: FeedbackClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackCliente = await _context.Feedbacks
                .FirstOrDefaultAsync(m => m.Id_feedback == id);
            if (feedbackCliente == null)
            {
                return NotFound();
            }

            return View(feedbackCliente);
        }

        // GET: FeedbackClientes/Create
        public IActionResult Create()
        {
            var clientes = _context.Clientes.Select(c => new SelectListItem
        {
            Value = c.Id_cliente.ToString(),
            Text = c.Nome}).ToList();

            ViewBag.Clientes = clientes;

            return View();
        }

        // POST: FeedbackClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_feedback,Id_cliente,Data_feedback,Comentario,Avaliacao")] FeedbackCliente feedbackCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedbackCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feedbackCliente);
        }

        // GET: FeedbackClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackCliente = await _context.Feedbacks.FindAsync(id);
            if (feedbackCliente == null)
            {
                return NotFound();
            }
            return View(feedbackCliente);
        }

        // POST: FeedbackClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_feedback,Id_cliente,Data_feedback,Comentario,Avaliacao")] FeedbackCliente feedbackCliente)
        {
            if (id != feedbackCliente.Id_feedback)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedbackCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackClienteExists(feedbackCliente.Id_feedback))
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
            return View(feedbackCliente);
        }

        // GET: FeedbackClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackCliente = await _context.Feedbacks
                .FirstOrDefaultAsync(m => m.Id_feedback == id);
            if (feedbackCliente == null)
            {
                return NotFound();
            }

            return View(feedbackCliente);
        }

        // POST: FeedbackClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedbackCliente = await _context.Feedbacks.FindAsync(id);
            if (feedbackCliente != null)
            {
                _context.Feedbacks.Remove(feedbackCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackClienteExists(int id)
        {
            return _context.Feedbacks.Any(e => e.Id_feedback == id);
        }

    }
}
