using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIStreamingUTHG1.DataAccess.Models
{
    public class Contenido
    {
        public decimal IdContenido { get; set; }

        public string TipoContenido { get; set; } = null!;

        public string? Titulo { get; set; } = null!;

        public string? Genero { get; set; } = null!;

        public string? YearLanzamiento { get; set; } = null!;

        public string? Descripcion { get; set; } = null!;

        public string? Director { get; set; } = null!;

        public string? Duracion { get; set; } = null!;

        public string? Calificaciones { get; set; } = null!;

        public string? Clasificaciones { get; set; } = null!;

        public decimal? IdRegion { get; set; } = null!;

        public string? CreatedAt { get; set; } = null!;

        public string? CreatedBy { get; set; } = null!;

        public string? UpdatedAt { get; set; } = null!;

        public string? UpdatedBy { get; set; } = null!;

        public string? Status { get; set; } = null!;
    }
}
