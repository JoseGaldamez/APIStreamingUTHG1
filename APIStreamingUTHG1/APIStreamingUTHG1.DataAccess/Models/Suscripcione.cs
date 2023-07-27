using System;
using System.Collections.Generic;

namespace APIStreamingUTHG1.DataAccess.Models;

public partial class Suscripcione
{
    public decimal IdSuscipcion { get; set; }

    public decimal? IdUsuario { get; set; }

    public decimal? IdPlan { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public string? EstadoPago { get; set; }

    public string CreatedAt { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string UpdatedAt { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public string Status { get; set; } = null!;
}
