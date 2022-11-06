using System;
using System.Collections.Generic;

namespace proyectoFi.Models
{
    public partial class Producto
    {
        public int CodProducto { get; set; }
        public string? NomProducto { get; set; }
        public string? TipoProducto { get; set; }
        public float? PrecioProducto { get; set; }
        public string? NomMarca { get; set; }

        public virtual Marca? NomMarcaNavigation { get; set; }
    }
}
