using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AEFINAL.Models;

public partial class Servicio
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre del servicio es obligatorio")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "el precio  es obligatorio")]
    [Range(1, 10000, ErrorMessage = "El valor debe ser mayor que 1 y menor a 10000")]
    public float Precio { get; set; }

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
