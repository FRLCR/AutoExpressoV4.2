using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AEFINAL.Models;

public partial class Registro
{
    public int NroOrden { get; set; }

    [Required(ErrorMessage = "La Fecha del Registro es obligatorio")]
    [DataType(DataType.Date)]       

    // No valida bien la fecha NI HARCODEANDOLO.
    //[Range(typeof(DateTime), "01-01-2023", "31-12-2023", ErrorMessage = "Error fecha invalida.")]
    [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
    public DateTime Fecha { get; set; }


    [Required(ErrorMessage = "La matricula del Registro es obligatorio")]
    [Display(Name = "Matricula del vehículo")]
    public string Vehiculomatricula { get; set; } = null!;


    [Required(ErrorMessage = "El servicio del Registro es obligatorio")]
    [Display(Name = "Servicio Realizado")]
    public int Servicioid { get; set; }

    public virtual Servicio Servicio { get; set; } = null!;
    [Display(Name = "Matricula del Vehículo")]
    public virtual Vehiculo VehiculomatriculaNavigation { get; set; } = null!;
}
