using System;
using System.Collections.Generic;

namespace APIStreamingUTHG1.DataAccess.Models;

public partial class Series
{
    public decimal IdSerie { get; set; }

    public string? Titulo { get; set; }

    public string? Genero { get; set; }

    public decimal? Temporadas { get; set; }

    public string? YearLanzamiento { get; set; }

    public string? Descripcion { get; set; }

    public string? Director { get; set; }

    public string? Duracion { get; set; }

    public string? Calificaciones { get; set; }

    public string? Clasificacion { get; set; }

    public decimal IdRegion { get; set; }

    public string CreatedAt { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string UpdatedAt { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Regione IdRegionNavigation { get; set; } = null!;

    public virtual ICollection<ValoracionesYComentario> ValoracionesYComentarios { get; set; } = new List<ValoracionesYComentario>();
}
