using APIStreamingUTHG1.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIStreamingUTHG1.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContenidosController : ControllerBase
    {

        private ModelContext _db;

        public ContenidosController(ModelContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<Contenido>> Listar()
        {
            var contenidosActivos = new List<Contenido>();
            var planes = await _db.Contenidos.ToListAsync();

            planes.ForEach(contenido => {
                if (contenido.Status == "1")
                {
                    contenidosActivos.Add(contenido);
                }
            });

            return contenidosActivos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contenido>> BuscarPorID(decimal id)
        {
            var resultado = await _db.Contenidos.FirstOrDefaultAsync(x => x.IdContenido == id);
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
        public async Task<ActionResult<Contenido>> Guardar(Contenido p)
        {

            try
            {
                await _db.Contenidos.AddAsync(p);
                await _db.SaveChangesAsync();

                p.IdContenido = await _db.Contenidos.MaxAsync(x => x.IdContenido);

                return p;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }


        [HttpPut]
        public async Task<ActionResult<Contenido>> Actualizar(Contenido p)
        {
            if (p == null || p.IdContenido == 0) return BadRequest("Faltan datos");

            Contenido contenido = await _db.Contenidos.FirstOrDefaultAsync(x => x.IdContenido == p.IdContenido);

            if (contenido == null) return NotFound();
            try
            {
                contenido.TipoContenido = p.TipoContenido;
                contenido.Titulo = p.Titulo;
                contenido.Genero = p.Genero;
                contenido.YearLanzamiento = p.YearLanzamiento;
                contenido.Descripcion = p.Descripcion;
                contenido.Director = p.Director;
                contenido.Calificaciones = p.Calificaciones;
                contenido.Clasificaciones = p.Clasificaciones;
                contenido.IdRegion = p.IdRegion;
                contenido.Duracion = p.Duracion;

                _db.Contenidos.Update(contenido);
                await _db.SaveChangesAsync();

                return contenido;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Contenido>> Borrar(decimal? id)
        {
            if (id == null || id == 0) return BadRequest("Faltan datos");

            Contenido contenido = await _db.Contenidos.FirstOrDefaultAsync(x => x.IdContenido == id);

            if (contenido == null) return NotFound();
            try
            {
                contenido.Status = "0";
                _db.Contenidos.Update(contenido);
                await _db.SaveChangesAsync();

                return contenido;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }


    }
}
