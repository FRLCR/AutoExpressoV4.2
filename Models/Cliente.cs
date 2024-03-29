﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AEFINAL.Models;

public partial class Cliente
{

    [Required(ErrorMessage = "El documento del cliente es obligatorio")]
    public int Documento { get; set; }

    //[Required(ErrorMessage = "El nombre del cliente es obligatorio")]
    //public string Nombre { get; set; } = null!;


    //[Required(ErrorMessage = "El apellido del cliente es obligatorio")]
    //public string Apellido { get; set; } = null!;

    [Required(ErrorMessage = "El nombre completo es un campo obligatorio")]
    [Display(Name = "Nombre completo del cliente")]
    public string NombreCompleto { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Ingrese una dirección de correo electrónico válida.")]
    [Display(Name = "Correo Electronico")]
    public string CorreoElectronico { get; set; } = null!;

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
