using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Variantes = new HashSet<Variante>();
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string Articulo { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string Precio { get; set; } = null!;

        public virtual ICollection<Variante> Variantes { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
