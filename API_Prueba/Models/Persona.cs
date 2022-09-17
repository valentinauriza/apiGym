using System;
using System.Collections.Generic;

namespace API_Prueba.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int Dni { get; set; }
        public Guid IdSexo { get; set; }
        public string Calle { get; set; } = null!;
        public int Numero { get; set; }

        public virtual Sexo IdSexoNavigation { get; set; } = null!;
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
