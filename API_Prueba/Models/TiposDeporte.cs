using System;
using System.Collections.Generic;

namespace API_Prueba.Models
{
    public partial class TiposDeporte
    {
        public TiposDeporte()
        {
            Deportes = new HashSet<Deporte>();
        }

        public Guid Id { get; set; }
        public string Tipo { get; set; } = null!;

        public virtual ICollection<Deporte> Deportes { get; set; }
    }
}
