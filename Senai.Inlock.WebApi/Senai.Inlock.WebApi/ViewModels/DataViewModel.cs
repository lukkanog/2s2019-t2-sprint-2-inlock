using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.ViewModels
{
    public class DataViewModel
    {
        public string NomeJogo { get; set; }
        public DateTime DataLancamento { get; set; }
        public int DiasFaltantes { get; set; }
    }
}
