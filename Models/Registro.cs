using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AEFINAL.Models;

public partial class Registro
{
    public int NroOrden { get; set; }

    [Required(ErrorMessage = "La Fecha del Registro es obligatorio")]
    [DataType(DataType.Date)]
   // [Range(typeof(DateTime), "01-01-1970", DateTime.Now.toString(), ErrorMessage = "Date of Birth Must be between 01-01-1970 and 01-01-2005")]
    [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
    public DateTime Fecha { get; set; }


    [Required(ErrorMessage = "La matricula del Registro es obligatorio")]
    [Display(Name = "Matricula del vehículo")]
    public string Vehiculomatricula { get; set; } = null!;


    [Required(ErrorMessage = "El servicio del Registro es obligatorio")]
    [Display(Name = "Servicio Realizado")]
    public int Servicioid { get; set; }

    public virtual Servicio Servicio { get; set; } = null!;

    public virtual Vehiculo VehiculomatriculaNavigation { get; set; } = null!;
}
