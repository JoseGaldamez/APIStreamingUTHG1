using APIStreamingUTHG1.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIStreamingUTHG1.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionesController : ControllerBase
    {
        private ModelContext _db;

        public RegionesController(ModelContext db)
        {
            this._db = db;
        }


        [HttpGet]
        public async Task<List<Regione>> Listar()
        {
            var regionesActivas = new List<Regione>();
            var regiones = await _db.Regiones.ToListAsync();

            regiones.ForEach(region => {
                if (region.Status == "1")
                {
                    regionesActivas.Add(region);
                }
            });

            return regionesActivas;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Regione>> BuscarPorID(decimal id)
        {
            var resultado = await _db.Regiones.FirstOrDefaultAsync(x => x.IdRegion == id);
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
        public async Task<ActionResult<Regione>> Guardar(Regione region)
        {

            try
            {
                await _db.Regiones.AddAsync(region);
                await _db.SaveChangesAsync();

                region.IdRegion = await _db.Regiones.MaxAsync(x => x.IdRegion);

                return region;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }


        [HttpPut]
        public async Task<ActionResult<Regione>> Actualizar(Regione region)
        {
            if (region == null || region.IdRegion == 0) return BadRequest("Faltan datos");

            Regione regi = await _db.Regiones.FirstOrDefaultAsync(x => x.IdRegion == region.IdRegion);

            if (regi == null) return NotFound();
            try
            {
                regi.NombreRegion = region.NombreRegion;
                regi.Descripcion = region.Descripcion;
                regi.Idioma = region.Idioma;
                regi.Pais = region.Pais;
                _db.Regiones.Update(regi);
                await _db.SaveChangesAsync();

                return regi;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Regione>> Borrar(decimal? id)
        {
            if (id == null || id == 0) return BadRequest("Faltan datos");

            Regione region = await _db.Regiones.FirstOrDefaultAsync(x => x.IdRegion == id);

            if (region == null) return NotFound();
            try
            {
                region.Status = "0";
                _db.Regiones.Update(region);
                await _db.SaveChangesAsync();

                return region;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }

    }
}
