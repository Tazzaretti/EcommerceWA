﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Envios
    {
        public Envios()
        {
            Ventas = new HashSet<Ventas>();
        }

        public int Id { get; set; }
        public string Destino { get; set; }
        public string Origen { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}