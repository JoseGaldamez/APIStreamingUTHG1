using System;
using System.Collections.Generic;

namespace APIStreamingUTHG1.DataAccess.Models;

public partial class Plane
{
    public decimal IdPlan { get; set; }

    public string NombrePlan { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal CostoMensual { get; set; }

    public string? CreatedAt { get; set; } = null!;

    public string? CreatedBy { get; set; } = null!;

    public string? UpdatedAt { get; set; } = null!;

    public string? UpdatedBy { get; set; } = null!;

    public string? Status { get; set; } = null!;
}
