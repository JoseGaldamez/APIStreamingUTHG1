using APIStreamingUTHG1.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace APIStreamingUTHG1.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanesController : ControllerBase
    {
        private ModelContext _db;

        public PlanesController(ModelContext db) {
            _db = db;
        }



        [HttpGet]
        public async Task<List<Plane>> Listar()
        {
            var plans = new List<Plane>();
            var planes = await _db.Planes.ToListAsync();

            planes.ForEach(plane => {
                if(plane.Status == "1")
                {
                    plans.Add(plane);
                }
            });

            return plans;
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Plane>> BuscarPorID(decimal id)
        {
            var resultado = await _db.Planes.FirstOrDefaultAsync(x => x.IdPlan == id);
            if(resultado != null)
            {
                return resultado;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Plane>> Guardar(Plane p)
        {

            try
            {
                await _db.Planes.AddAsync(p);
                await _db.SaveChangesAsync();

                p.IdPlan = await _db.Planes.MaxAsync(x => x.IdPlan);

                return p;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }


        [HttpPut]
        public async Task<ActionResult<Plane>> Actualizar(Plane p)
        {
            if (p == null || p.IdPlan == 0) return BadRequest("Faltan datos");

            Plane plan = await _db.Planes.FirstOrDefaultAsync(x => x.IdPlan == p.IdPlan);

            if (plan == null) return NotFound();
            try
            {
                plan.NombrePlan = p.NombrePlan;
                plan.Descripcion = p.Descripcion;
                plan.CostoMensual = p.CostoMensual;
                _db.Planes.Update(plan);
                await _db.SaveChangesAsync();

                return plan;
            } catch(DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Plane>> Borrar(decimal? id)
        {
            if (id == null || id == 0) return BadRequest("Faltan datos");

            Plane plan = await _db.Planes.FirstOrDefaultAsync(x => x.IdPlan == id);

            if (plan == null) return NotFound();
            try
            {
                plan.Status = "0";
                _db.Planes.Update(plan);
                await _db.SaveChangesAsync();

                return plan;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }

    }
}
