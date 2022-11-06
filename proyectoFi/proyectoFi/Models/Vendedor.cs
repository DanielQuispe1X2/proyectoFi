using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyectoFi.Models
{
    public partial class Vendedor
    {
        [Required(ErrorMessage ="El campo id es obligatorio")]
        public int CodVendedor { get; set; }
        
        [Required(ErrorMessage ="El campo nombre vendedor es obligatorio")]
        public string? NomVendedor { get; set; }

        [Required(ErrorMessage ="El campo apellido es obligatorio")]
        public string? ApeVendedor { get; set; }

        [Required(ErrorMessage ="El campo telefono vendedor es obligatorio")]
        public int? TelVendedor { get; set; }
    }
}
