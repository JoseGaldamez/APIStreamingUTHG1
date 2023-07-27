using System;
using System.Collections.Generic;

namespace APIStreamingUTHG1.DataAccess.Models;

public partial class ValoracionesYComentario
{
    public decimal IdValoracionc { get; set; }

    public decimal IdUsuario { get; set; }

    public decimal? IdPelicula { get; set; }

    public decimal? IdSerie { get; set; }

    public string? Comentario { get; set; }

    public DateTime? FechaComentario { get; set; }

    public decimal? Valoracion { get; set; }

    public string CreatedAt { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public string Status { get; set; } = null!;

    public virtual Pelicula? IdPeliculaNavigation { get; set; }

    public virtual Series? IdSerieNavigation { get; set; }

    public virtual User IdUsuarioNavigation { get; set; } = null!;
}
