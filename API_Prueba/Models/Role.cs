using System;
using System.Collections.Generic;

namespace API_Prueba.Models
{
    public partial class Role
    {
        public Role()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public Guid Id { get; set; }
        public string Rol { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
