using System;
using System.Collections.Generic;

namespace proyectoFi.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public int CodCliente { get; set; }
        public string? NomCliente { get; set; }
        public string? ApeCliente { get; set; }
        public int? DniCliente { get; set; }
        public string? DireCliente { get; set; }

        public int? telefono { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
