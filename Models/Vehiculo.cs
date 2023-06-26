using System;
using System.Collections.Generic;

namespace AEFINAL.Models;

public partial class Vehiculo
{
    public string Matricula { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public int Clientedocumento { get; set; }

    public virtual Cliente ClientedocumentoNavigation { get; set; } = null!;

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
