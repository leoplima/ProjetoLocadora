using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        public int Codigo { get; set; }
        public string CodBarras { get; set; }
        public int CodCategoria { get; set; }
        public string Nome { get; set; }
        public int CodGenero { get; set; }
        public string Ano { get; set; }
        public int CodTipo { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
        public decimal VrCusto { get; set; }
        public int CodSituacao { get; set; }
        public int CodArtista { get; set; }
        public string Diretor { get; set; }
        public string Foto { get; set; }

    }
}
