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

    public string? CreatedAt { get; set; } = null!;

    public string? CreatedBy { get; set; } = null!;

    public string? UpdatedAt { get; set; } = null!;

    public string? UpdatedBy { get; set; } = null!;

    public string? Status { get; set; } = null!;

}
