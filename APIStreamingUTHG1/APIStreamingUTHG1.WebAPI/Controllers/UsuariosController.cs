using APIStreamingUTHG1.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace APIStreamingUTHG1.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private ModelContext _db;
        public UsuariosController(ModelContext db) {
            this._db = db;
        }

        [HttpGet]
        public async Task<List<User>> Listar()
        {
            var usersActivos = new List<User>();
            var users = await _db.Users.ToListAsync();

            users.ForEach(user => {
                if (user.Status == "1")
                {
                    usersActivos.Add(user);
                }
            });

            return usersActivos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> BuscarPorID(decimal id)
        {
            var resultado = await _db.Users.FirstOrDefaultAsync(x => x.IdUsuario == id);
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
        public async Task<ActionResult<User>> Guardar(User p)
        {

            try
            {
                await _db.Users.AddAsync(p);
                await _db.SaveChangesAsync();

                p.IdUsuario = await _db.Users.MaxAsync(x => x.IdUsuario);

                return p;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }

        [HttpPut]
        public async Task<ActionResult<User>> Actualizar(User p)
        {
            if (p == null || p.IdUsuario == 0) return BadRequest("Faltan datos");

            User userAct = await _db.Users.FirstOrDefaultAsync(x => x.IdUsuario == p.IdUsuario);

            if (userAct == null) return NotFound();
            try
            {
                userAct.Nombre = p.Nombre;
                userAct.Contrasena = p.Contrasena;
                userAct.Email = p.Email;

                _db.Users.Update(userAct);
                await _db.SaveChangesAsync();

                return userAct;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Borrar(decimal? id)
        {
            if (id == null || id == 0) return BadRequest("Faltan datos");

            User userAct = await _db.Users.FirstOrDefaultAsync(x => x.IdUsuario == id);

            if (userAct == null) return NotFound();
            try
            {
                userAct.Status = "0";
                _db.Users.Update(userAct);
                await _db.SaveChangesAsync();

                return userAct;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }

        }

    }
}
