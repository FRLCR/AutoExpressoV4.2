using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AEFINAL.Models;

public partial class Vehiculo
{

    [Required(ErrorMessage = "La matricula del auto es obligatoria")]
    [Display(Name = "Matrícula")]
    public string Matricula { get; set; } = null!;


    [Required(ErrorMessage = "La marca del auto es obligatoria")]
    public string Marca { get; set; } = null!;

    [Required(ErrorMessage = "El modelo del auto es obligatorio")]
    public string Modelo { get; set; } = null!;

    [Display(Name = "Documento del Cliente")]
    public int Clientedocumento { get; set; }

    public virtual Cliente ClientedocumentoNavigation { get; set; } = null!;

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
