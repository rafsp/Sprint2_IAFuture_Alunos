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
    public class InteracaoClientesController : Controller
    {
        private readonly OracleDbContext _context;

        public InteracaoClientesController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: InteracaoClientes
        public async Task<IActionResult> Index()
        {
            var interacoes = await _context.Interacoes.Include(f => f.Cliente).ToListAsync();
            return View(interacoes);
        }

        // GET: InteracaoClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interacaoCliente = await _context.Interacoes
                .FirstOrDefaultAsync(m => m.Id_interacao == id);
            if (interacaoCliente == null)
            {
                return NotFound();
            }

            return View(interacaoCliente);
        }

        // GET: InteracaoClientes/Create
        public IActionResult Create()
        {
            // Aqui você pode carregar uma lista de clientes para o dropdown na view
            var clientes = _context.Clientes.Select(c => new SelectListItem
            {
                Value = c.Id_cliente.ToString(),
                Text = c.Nome
            }).ToList();

            ViewBag.Clientes = clientes;

            return View();
        }

        // POST: InteracaoClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_interacao,Id_cliente,Data_interacao,Tipo,Canal")] InteracaoCliente interacaoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interacaoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interacaoCliente);
        }

        // GET: InteracaoClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interacaoCliente = await _context.Interacoes.FindAsync(id);
            if (interacaoCliente == null)
            {
                return NotFound();
            }
            return View(interacaoCliente);
        }

        // POST: InteracaoClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_interacao,Id_cliente,Data_interacao,Tipo,Canal")] InteracaoCliente interacaoCliente)
        {
            if (id != interacaoCliente.Id_interacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interacaoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InteracaoClienteExists(interacaoCliente.Id_interacao))
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
            return View(interacaoCliente);
        }

        // GET: InteracaoClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interacaoCliente = await _context.Interacoes
                .FirstOrDefaultAsync(m => m.Id_interacao == id);
            if (interacaoCliente == null)
            {
                return NotFound();
            }

            return View(interacaoCliente);
        }

        // POST: InteracaoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interacaoCliente = await _context.Interacoes.FindAsync(id);
            if (interacaoCliente != null)
            {
                _context.Interacoes.Remove(interacaoCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InteracaoClienteExists(int id)
        {
            return _context.Interacoes.Any(e => e.Id_interacao == id);
        }
    }
}
