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
    public class CursosController : Controller
    {
        private readonly EducacionalContext _context;

        public CursosController(EducacionalContext context)
        {
            _context = context;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
        {
            var educacionalContext = _context.Curso.Include(c => c.Departamento);
            return View(await educacionalContext.ToListAsync());
        }

        // GET: Cursos/Details/5
        [Route("Cursos/Detalhes")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .Include(c => c.Departamento)
                .FirstOrDefaultAsync(m => m.CursoID == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Cursos/Create
        [Route("Cursos/Criar")]
        public IActionResult Create()
        {
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "Nome");
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Route("Cursos/Criar")]
        public async Task<IActionResult> Create([Bind("CursoID,Nome,CargaHoraria,DepartamentoID")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "Nome", curso.DepartamentoID);
            return View(curso);
        }

        // GET: Cursos/Edit/5
        [HttpGet("Cursos/Editar/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "Nome", curso.DepartamentoID);
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Cursos/Editar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CursoID,Nome,CargaHoraria,DepartamentoID")] Curso curso)
        {
            if (id != curso.CursoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.CursoID))
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
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "Nome", curso.DepartamentoID);
            return View(curso);
        }

        // GET: Cursos/Delete/5
        [HttpGet("Cursos/Deletar/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .Include(c => c.Departamento)
                .FirstOrDefaultAsync(m => m.CursoID == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost("Cursos/Deletar/{id}")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var curso = await _context.Curso.FindAsync(id);
            if (curso != null)
            {
                _context.Curso.Remove(curso);
                
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
            return _context.Curso.Any(e => e.CursoID == id);
        }
    }
}
