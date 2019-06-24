using ENGCOMP022019_ANALISADORLEXICO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANALISADOR_LEXICO_ENGCOMP201902
{
    public class TabelaDeSimbolos
    {
        //public Item Itens { get; set; }
        public Token token { get; set; }

        public TabelaDeSimbolos(Token t)
        {
            token = t;
        }
        
    }

    public class Item
    {
        public int Indice { get; set; } //número da entrada da tabela de símbolos 
        public string Codigo { get; set; } //código do átomo
        public string lexeme { get; set; } //quantidade de caracteres antes da truncagem
        public string QuatidadeTruncada { get; set; } //quantidade de caracteres depois da truncagem
        public string TipoSimbolo { get; set; } //tipo do símbolo

        public List<int> PrimeirasLinhas = new List<int>(); //cinco primeiras linhas onde o símbolo aparece

    }
}
