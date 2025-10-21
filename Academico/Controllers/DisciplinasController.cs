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
    public class DisciplinasController : Controller
    {
        private readonly EducacionalContext _context;

        public DisciplinasController(EducacionalContext context)
        {
            _context = context;
        }

        // GET: Disciplinas
        public async Task<IActionResult> Index()
        {
            var educacionalContext = _context.Disciplina.Include(d => d.Curso);
            return View(await educacionalContext.ToListAsync());
        }

        [Route("Disciplinas/Detalhes")]

        // GET: Disciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplina
                .Include(d => d.Curso)
                .FirstOrDefaultAsync(m => m.DisciplinaID == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // GET: Disciplinas/Create

        [Route("Disciplinas/Criar")]
        public IActionResult Create()
        {
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "Nome");
            return View();
        }

        // POST: Disciplinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Disciplinas/Criar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisciplinaID,Nome,CargaHoraria,CursoID")] Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "Nome", disciplina.CursoID);
            return View(disciplina);
        }

        // GET: Disciplinas/Edit/5
        [HttpGet("Disciplinas/Editar/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplina.FindAsync(id);
            if (disciplina == null)
            {
                return NotFound();
            }
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "Nome", disciplina.CursoID);
            return View(disciplina);
        }

        // POST: Disciplinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Disciplinas/Editar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisciplinaID,Nome,CargaHoraria,CursoID")] Disciplina disciplina)
        {
            if (id != disciplina.DisciplinaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplinaExists(disciplina.DisciplinaID))
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
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "Nome", disciplina.CursoID);
            return View(disciplina);
        }

        // GET: Disciplinas/Delete/5
        [HttpGet("Disciplinas/Deletar/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplina
                .Include(d => d.Curso)
                .FirstOrDefaultAsync(m => m.DisciplinaID == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // POST: Disciplinas/Delete/5
        [HttpPost("Disciplinas/Deletar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disciplina = await _context.Disciplina.FindAsync(id);
            if (disciplina != null)
            {
                _context.Disciplina.Remove(disciplina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplinaExists(int id)
        {
            return _context.Disciplina.Any(e => e.DisciplinaID == id);
        }
    }
}
