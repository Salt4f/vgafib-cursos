using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VGAFIBCursos.Data;
using VGAFIBCursos.Models;

namespace VGAFIBCursos.Controllers
{
    public class CursosController : Controller
    {
        private readonly DataContext _context;

        public CursosController(DataContext context)
        {
            _context = context;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cursos!.ToListAsync());
        }

        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind(nameof(Estudiante.CursoId),nameof(Estudiante.Nombre),nameof(Estudiante.Apellidos),nameof(Estudiante.Dni),nameof(Estudiante.NombreCompanero),nameof(Estudiante.Email),nameof(Estudiante.Fiber))]Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                estudiante.FechaInscripcion = DateTime.UtcNow;
                await _context.AddAsync(estudiante);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return View(false);
                }
                return View(true);
            }
            return View(false);
        }

    }
}
