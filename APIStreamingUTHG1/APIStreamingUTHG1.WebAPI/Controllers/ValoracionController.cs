using APIStreamingUTHG1.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIStreamingUTHG1.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValoracionController : ControllerBase
    {

        private ModelContext _db;

        public ValoracionController(ModelContext db)
        {
            this._db = db;
        }

        // GET: api/Valoracion
        [HttpGet]
        public async Task<List<ValoracionesYComentario>> GetValoraciones()
        {
            return await _db.ValoracionesYComentarios.Where(valoracion => valoracion.Status == "1") .ToListAsync();
        }

        // GET: api/Valoracion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ValoracionesYComentario>> GetValoracion(int id)
        {
            var valoracion = await _db.ValoracionesYComentarios.FirstOrDefaultAsync( x => x.IdValoracionc == id);

            if (valoracion == null)
            {
                return NotFound();
            }

            return Ok(valoracion);
        }

        // POST: api/Valoracion
        [HttpPost]
        public async Task<IActionResult> CreateValoracion([FromBody] ValoracionesYComentario valoracion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.ValoracionesYComentarios.Add(valoracion);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetValoracion), new { id = valoracion.IdValoracionc }, valoracion);
        }

        // PUT: api/Valoracion/5
        [HttpPut]
        public async Task<ActionResult<ValoracionesYComentario>> UpdateValoracion([FromBody] ValoracionesYComentario valoracion)
        {
            if (!ModelState.IsValid || valoracion.IdValoracionc == 0 )
            {
                return BadRequest(ModelState);
            }

            ValoracionesYComentario actual = await _db.ValoracionesYComentarios.FirstOrDefaultAsync(x => x.IdValoracionc == valoracion.IdValoracionc);

            if (actual == null) return NotFound();
            try
            {
                actual.Comentario = valoracion.Comentario;
                actual.FechaComentario = valoracion.FechaComentario;
                actual.Valoracion = valoracion.Valoracion;

                _db.ValoracionesYComentarios.Update(actual);
                await _db.SaveChangesAsync();

                return actual;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }
        }

        // PUT: api/Valoracion/5
        [HttpPost("{id}")]
        public async Task<ActionResult<ValoracionesYComentario>> UpdateDeleteValoracion(int id)
        {
            var valoracion = await _db.ValoracionesYComentarios.FirstOrDefaultAsync(x => x.IdValoracionc == id);

            if (valoracion == null) return NotFound();
            try
            {
                valoracion.Status = "0";
                _db.ValoracionesYComentarios.Update(valoracion);
                await _db.SaveChangesAsync();

                return valoracion;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }
        }

        // DELETE: api/Valoracion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ValoracionesYComentario>> DeleteValoracion(int id)
        {
            var valoracion = await _db.ValoracionesYComentarios.FirstOrDefaultAsync(x => x.IdValoracionc == id);

            if (valoracion == null) return NotFound();
            try
            {
                valoracion.Status = "0";
                _db.ValoracionesYComentarios.Update(valoracion);
                await _db.SaveChangesAsync();

                return valoracion;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }
        }


    }
}
