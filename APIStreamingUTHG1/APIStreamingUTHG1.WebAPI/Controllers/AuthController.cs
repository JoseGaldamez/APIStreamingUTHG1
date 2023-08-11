using APIStreamingUTHG1.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIStreamingUTHG1.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ModelContext _db;
        public AuthController(ModelContext db)
        {
            this._db = db;
        }


        [HttpGet("{email}")]
        public async Task<ActionResult<User>> BuscarPorEmail(string email)
        {
            var resultado = await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                return NotFound();
            }
        }


    }
}
