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

        public PlanesController( ModelContext db ) {
            _db = db;
        }

        [HttpGet]
        public async Task<List<Plane>> Listar()
        {
            return await _db.Planes.ToListAsync();
        }
    }
}
