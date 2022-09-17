using System;
using System.Collections.Generic;

namespace API_Prueba.Models
{
    public partial class Usuario
    {
        public Guid Id { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }
        public Guid IdRol { get; set; }
        public Guid IdPersona { get; set; }
        public Guid IdDeporte { get; set; }

        public virtual Deporte IdDeporteNavigation { get; set; } = null!;
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual Role IdRolNavigation { get; set; } = null!;
    }
}
