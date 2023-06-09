using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class User
    {
        public User()
        {
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Tel { get; set; } = null!;

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
