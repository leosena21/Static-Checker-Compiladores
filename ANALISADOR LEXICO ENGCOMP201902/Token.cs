using System;
using System.Collections.Generic;
using System.Text;

namespace ENGCOMP022019_ANALISADORLEXICO
{
    public class Token
    {
        public char Caractere { get; set; }
        public string Lexeme { get; set; }
        public string Codigo { get; set; }
        //public int Posicao { get; set; }
        public List<int> LinhasApareceu = new List<int>();
        public int Tamanho1 { get; set; }
        public int Tamanho2 { get; set; }
        public int QuantidadeAparicoes { get; set; }
        public Categoria Categoria { get; set; }

        public Token()
        {

        }
        public Token(Token t)
        {
            Caractere = t.Caractere;
            Lexeme = t.Lexeme;
            Codigo = t.Codigo;
            LinhasApareceu = t.LinhasApareceu;
            Tamanho1 = t.Tamanho1;
            Tamanho2 = t.Tamanho2;
            QuantidadeAparicoes = t.QuantidadeAparicoes;
            Categoria = t.Categoria;
        }

    }

    public class Categoria
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public Categoria()
        {

        }
    }
}

