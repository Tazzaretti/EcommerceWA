using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Variante
    {
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        public int IdProducto { get; set; }
        public string Talle { get; set; } = null!;

        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
