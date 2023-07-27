using System;
using System.Collections.Generic;

namespace APIStreamingUTHG1.DataAccess.Models;

public partial class User
{
    public decimal IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string CreatedAt { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string UpdatedAt { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<ValoracionesYComentario> ValoracionesYComentarios { get; set; } = new List<ValoracionesYComentario>();
}
