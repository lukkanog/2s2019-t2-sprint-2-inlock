using System;
using System.Collections.Generic;

namespace Senai.Inlock.WebApi.Domains
{
    public partial class TiposUsuarios
    {
        public TiposUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int TipoId { get; set; }
        public string DescricaoTipo { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
