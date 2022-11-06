using System;
using System.Collections.Generic;

namespace proyectoFi.Models
{
    public partial class Factura
    {
        public int CodFactura { get; set; }
        public string? Fecha { get; set; }
        public float? Subtotal { get; set; }
        public float? IgvFactura { get; set; }
        public float? Total { get; set; }
        public string? Estado { get; set; }
        public string? TipoVenta { get; set; }
        public int CodCliente { get; set; }

        public virtual Cliente CodClienteNavigation { get; set; } = null!;
    }
}
