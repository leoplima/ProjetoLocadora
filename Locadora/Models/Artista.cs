using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class Artista
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string Pais { get; set; }
        public string Foto { get; set; }
    }
}
