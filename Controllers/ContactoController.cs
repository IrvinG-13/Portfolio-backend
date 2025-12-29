using irvinPortfolio.Data;
using irvinPortfolio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace irvinPortfolio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactoController : ControllerBase
    {
        private readonly AplicacionDbContext _context;

        public ContactoController(AplicacionDbContext context)
        {
            _context = context;
        }

        // POST api/contacto
        [HttpPost]
        public async Task<IActionResult> EnviarMensaje(MensajeContacto mensaje)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.modeloMensajeContacto.Add(mensaje);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Mensaje enviado correctamente" });
        }


        // GET api/contacto
        [HttpGet]
        public async Task<IActionResult> ObtenerMensajes()
        {
            var mensajes = await _context.modeloMensajeContacto.ToListAsync();
            return Ok(mensajes);
        }

        // PUT api/contacto/{id}/leido
        [HttpPut("{id}/leido")]
        public async Task<IActionResult> MarcarLeido(int id)
        {
            var mensaje = await _context.modeloMensajeContacto.FindAsync(id);
            if (mensaje == null) return NotFound();

            mensaje.Leido = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/contacto/{id}
        [Authorize] // 🔒 solo admin
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarMensaje(int id)
        {
            var mensaje = await _context.modeloMensajeContacto.FindAsync(id);
            if (mensaje == null) return NotFound();

            _context.modeloMensajeContacto.Remove(mensaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
