using System;
using System.Collections.Generic;

namespace Senai.Inlock.WebApi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Estudios = new HashSet<Estudios>();
            Jogos = new HashSet<Jogos>();
        }

        public int UsuarioId { get; set; }
        public int? TipoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public TiposUsuarios TipoUsuarioNavigation { get; set; }
        public ICollection<Estudios> Estudios { get; set; }
        public ICollection<Jogos> Jogos { get; set; }
        //public object Permissao { get; internal set; }
    }
}
