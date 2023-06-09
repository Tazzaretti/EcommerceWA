using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Venta
    {
        public int IdEnvio { get; set; }
        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        public virtual Envio IdEnvioNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual User IdUsuarioNavigation { get; set; } = null!;
    }
}
