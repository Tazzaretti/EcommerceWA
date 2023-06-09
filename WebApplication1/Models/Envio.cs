using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Envio
    {
        public Envio()
        {
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string Destino { get; set; } = null!;
        public string Origen { get; set; } = null!;

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
