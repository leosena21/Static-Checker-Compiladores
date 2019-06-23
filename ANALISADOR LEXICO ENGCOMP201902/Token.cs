using System;
using System.Collections.Generic;
using System.Text;

namespace ENGCOMP022019_ANALISADORLEXICO
{
    public class Token
    {
        public char Caractere { get; set; }
        public string Lexema { get; set; }
        public string Codigo { get; set; }
        public int Posicao { get; set; }
        public List<int> LinhasApareceu = new List<int>();
        public int ValorInteiro { get; set; }
        public float ValorFloat { get; set; }
        public int QuantidadeAparicoes { get; set; }
        public Categoria Categoria { get; set; }
        public Token()
        {

        }

    }

    public class Categoria
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public Categoria()
        {

        }
    }
}

