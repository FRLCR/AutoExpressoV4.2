using System;
using System.Collections.Generic;

namespace AEFINAL.Models;

public partial class Registro
{
    public int NroOrden { get; set; }

    public string Fecha { get; set; } = null!;

    public string Vehiculomatricula { get; set; } = null!;

    public int Servicioid { get; set; }

    public virtual Servicio Servicio { get; set; } = null!;

    public virtual Vehiculo VehiculomatriculaNavigation { get; set; } = null!;
}
