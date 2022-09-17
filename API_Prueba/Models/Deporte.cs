using System;
using System.Collections.Generic;

namespace API_Prueba.Models
{
    public partial class Deporte
    {
        public Deporte()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public Guid IdTipoDeporte { get; set; }

        public virtual TiposDeporte IdTipoDeporteNavigation { get; set; } = null!;
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
