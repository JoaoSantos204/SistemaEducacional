using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academico.Data;
using Academico.Models;

namespace Academico.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly EducacionalContext _context;

        public DepartamentosController(EducacionalContext context)
        {
            _context = context;
        }

        
        // GET: Departamentos
        public async Task<IActionResult> Index()
        {
            var educacionalContext = _context.Departamentos.Include(d => d.Instituicao);
            return View(await educacionalContext.ToListAsync());
        }

        // GET: Departamentos/Details/5
        [Route("Departamentos/Detalhes")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
                .Include(d => d.Instituicao)
                .FirstOrDefaultAsync(m => m.DepartamentoID == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamentos/Create
        [Route("Departamentos/Criar")]
        public IActionResult Create()
        {
            ViewData["InstituicaoID"] = new SelectList(_context.Instituicoes, "InstituicaoID", "Nome");
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Departamentos/Criar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartamentoID,Nome,InstituicaoID")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstituicaoID"] = new SelectList(_context.Instituicoes, "InstituicaoID", "Nome", departamento.InstituicaoID);
            return View(departamento);
        }

        // GET: Departamentos/Edit/5
        [HttpGet("Departamentos/Editar/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            ViewData["InstituicaoID"] = new SelectList(_context.Instituicoes, "InstituicaoID", "Nome", departamento.InstituicaoID);
            return View(departamento);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Departamentos/Editar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartamentoID,Nome,InstituicaoID")] Departamento departamento)
        {
            if (id != departamento.DepartamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.DepartamentoID))
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
            ViewData["InstituicaoID"] = new SelectList(_context.Instituicoes, "InstituicaoID", "Nome", departamento.InstituicaoID);
            return View(departamento);
        }

        // GET: Departamentos/Delete/5
        [HttpGet("Departamentos/Deletar/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
                .Include(d => d.Instituicao)
                .FirstOrDefaultAsync(m => m.DepartamentoID == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: Departamentos/Delete/5
        [HttpPost("Departamentos/Deletar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento != null)
            {
                _context.Departamentos.Remove(departamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.DepartamentoID == id);
        }
    }
}
