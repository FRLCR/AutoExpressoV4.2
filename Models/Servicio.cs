using System;
using System.Collections.Generic;

namespace AEFINAL.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public float Precio { get; set; }

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
