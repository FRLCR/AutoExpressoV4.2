using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AEFINAL.Models;

public partial class Registro
{
    public int NroOrden { get; set; }

    [Required(ErrorMessage = "La Fecha del Registro es obligatorio")]
    public string Fecha { get; set; } = null!;


    [Required(ErrorMessage = "La matricula del Registro es obligatorio")]
    [Display(Name = "Matricula del vehículo")]

    public string Vehiculomatricula { get; set; } = null!;


    [Required(ErrorMessage = "El servicio del Registro es obligatorio")]
    [Display(Name = "Servicio Realizado")]
    public int Servicioid { get; set; }

    public virtual Servicio Servicio { get; set; } = null!;

    public virtual Vehiculo VehiculomatriculaNavigation { get; set; } = null!;
}
