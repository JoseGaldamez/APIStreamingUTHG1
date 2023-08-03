using APIStreamingUTHG1.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIStreamingUTHG1.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumenController : ControllerBase
    {

        private ModelContext _db;

        public ResumenController(ModelContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<Resumen>> Listar()
        {
            return await _db.Resumens.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Resumen>> BuscarPorID(decimal id)
        {
            var resultado = await _db.Resumens.FirstOrDefaultAsync(x => x.IdResumen == id);
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
        public async Task<ActionResult<Resumen>> Guardar(Resumen Resm)
        {

            try
            {
                await _db.Resumens.AddAsync(Resm);
                await _db.SaveChangesAsync();

                Resm.IdResumen = await _db.Resumens.MaxAsync(x => x.IdResumen);

                return Resm;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }


        [HttpPut]
        public async Task<ActionResult<Resumen>> Actualizar(Resumen R)
        {
            if (R == null || R.IdResumen == 0) return BadRequest("Faltan datos");

            Resumen res = await _db.Resumens.FirstOrDefaultAsync(x => x.IdResumen == R.IdResumen);

            if (res == null) return NotFound();
            try
            {

                res.IdContenido = R.IdContenido;
                res.IdUsuario = R.IdUsuario;
                res.IdSuscripcion = R.IdSuscripcion;
                res.IdPlan = R.IdPlan;
                res.IdValoracion = R.IdValoracion;
                res.IdRegion = R.IdRegion;
                res.IdHistorial = R.IdHistorial;

                _db.Resumens.Update(res);
                await _db.SaveChangesAsync();

                return res;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Resumen>> Borrar(decimal? id)
        {
            if (id == null || id == 0) return BadRequest("Faltan datos");

            Resumen res = await _db.Resumens.FirstOrDefaultAsync(x => x.IdResumen == id);

            if (res == null) return NotFound();
            try
            {
                _db.Resumens.Update(res);
                await _db.SaveChangesAsync();

                return res;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }



    }
}
