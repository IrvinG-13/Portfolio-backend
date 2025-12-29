using irvinPortfolio.Data;
using irvinPortfolio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace irvinPortfolio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectosController : ControllerBase
    {
        private readonly AplicacionDbContext _context;

        public ProyectosController(AplicacionDbContext context)
        {
            _context = context;
        }

        // GET api/proyectos
        [HttpGet]
        public async Task<IActionResult> ObtenerProyectos()
        {
            var proyectos = await _context.modeloProyectos.ToListAsync();
            return Ok(proyectos);
        }

        // GET api/proyectos/destacados
        [HttpGet("destacados")]
        public async Task<IActionResult> ObtenerProyectosDestacados()
        {
            var proyectos = await _context.modeloProyectos
                .Where(p => p.Destacado)
                .ToListAsync();
            return Ok(proyectos);
        }

        // POST api/proyectos
        [Authorize] // Solo admin puede crear
        [HttpPost]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CrearProyecto(ModeloProyecto proyecto)
        {
            _context.modeloProyectos.Add(proyecto);
            await _context.SaveChangesAsync();
            return Ok(proyecto);
        }


        // PUT api/proyectos/{id}
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProyecto(int id, ModeloProyecto proyectoActualizado)
        {
            var proyecto = await _context.modeloProyectos.FindAsync(id);
            if (proyecto == null) return NotFound();

            proyecto.Titulo = proyectoActualizado.Titulo;
            proyecto.Descripcion = proyectoActualizado.Descripcion;
            proyecto.Tecnologias = proyectoActualizado.Tecnologias;
            proyecto.ImagenUrl = proyectoActualizado.ImagenUrl;
            proyecto.RepoUrl = proyectoActualizado.RepoUrl;
            proyecto.DemoUrl = proyectoActualizado.DemoUrl;
            proyecto.Destacado = proyectoActualizado.Destacado;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/proyectos/{id}
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProyecto(int id)
        {
            var proyecto = await _context.modeloProyectos.FindAsync(id);
            if (proyecto == null) return NotFound();

            _context.modeloProyectos.Remove(proyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
