using APIStreamingUTHG1.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIStreamingUTHG1.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuscripcionController : ControllerBase
    {
        private ModelContext _db;
        public SuscripcionController(ModelContext db)
        {
            this._db = db;
        }

        [HttpGet]
        public async Task<List<Suscripcione>> Listar()
        {
            return await _db.Suscripciones.Where(x => x.Status == "1").ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Suscripcione>> BuscarPorID(decimal id)
        {
            var resultado = await _db.Suscripciones.FirstOrDefaultAsync(x => x.IdSuscipcion == id);
            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public async Task<ActionResult<Suscripcione>> Guardar(Suscripcione p)
        {

            try
            {
                await _db.Suscripciones.AddAsync(p);
                await _db.SaveChangesAsync();

                p.IdSuscipcion = await _db.Suscripciones.MaxAsync(x => x.IdSuscipcion);

                return p;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Suscripcione>> Actualizar(Suscripcione p)
        {
            if (p == null || p.IdSuscipcion == 0) return BadRequest("Faltan datos");

            Suscripcione suscripcionAct = await _db.Suscripciones.FirstOrDefaultAsync(x => x.IdSuscipcion == p.IdSuscipcion);

            if (suscripcionAct == null) return NotFound();
            try
            {
                suscripcionAct.IdPlan = p.IdPlan;
                suscripcionAct.FechaInicio = p.FechaInicio;
                suscripcionAct.FechaVencimiento = p.FechaVencimiento;
                suscripcionAct.EstadoPago = p.EstadoPago;
                
                _db.Suscripciones.Update(suscripcionAct);
                await _db.SaveChangesAsync();

                return suscripcionAct;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Suscripcione>> Borrar(decimal? id)
        {
            if (id == null || id == 0) return BadRequest("Faltan datos");

            Suscripcione suscripcionAct = await _db.Suscripciones.FirstOrDefaultAsync(x => x.IdSuscipcion == id);

            if (suscripcionAct == null) return NotFound();
            try
            {
                suscripcionAct.Status = "0";
                _db.Suscripciones.Update(suscripcionAct);
                await _db.SaveChangesAsync();

                return suscripcionAct;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }
    }
}
