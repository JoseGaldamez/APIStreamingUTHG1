using System;
using System.Collections.Generic;

namespace APIStreamingUTHG1.DataAccess.Models;

public partial class Regione
{
    public decimal IdRegion { get; set; }

    public string NombreRegion { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Pais { get; set; } = null!;

    public string Idioma { get; set; } = null!;

    public virtual ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();

    public virtual ICollection<Series> Series { get; set; } = new List<Series>();
}
