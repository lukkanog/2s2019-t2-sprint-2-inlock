using System;
using System.Collections.Generic;

namespace Senai.Inlock.WebApi.Domains
{
    public partial class Paises
    {
        public Paises()
        {
            Estudios = new HashSet<Estudios>();
        }

        public int PaisId { get; set; }
        public string NomePais { get; set; }

        public ICollection<Estudios> Estudios { get; set; }
    }
}
