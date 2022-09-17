using System;
using System.Collections.Generic;

namespace API_Prueba.Models
{
    public partial class Sexo
    {
        public Sexo()
        {
            Personas = new HashSet<Persona>();
        }

        public Guid Id { get; set; }
        public string Sexo1 { get; set; } = null!;

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
