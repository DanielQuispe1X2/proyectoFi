using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyectoFi.Models
{
    public partial class Marca
    {
        

        public Marca()
        {
            Productos = new HashSet<Producto>();
        }

        [Required(ErrorMessage="El campo NOMBRE es obligatorio")]
        public string NomMarca { get; set; } = null!;

        
        public int? IdMarca { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
