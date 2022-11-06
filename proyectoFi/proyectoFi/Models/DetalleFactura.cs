using System;
using System.Collections.Generic;

namespace proyectoFi.Models
{
    public partial class DetalleFactura
    {
        public int? CodProducto { get; set; }
        public int? CodFactura { get; set; }
        public int? Cantidad { get; set; }
        public float? PrecioVenta { get; set; }
    }
}
