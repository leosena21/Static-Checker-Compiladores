using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Compiladores
{
    public class Lexico
    {
        public char[] entrada;
        bool reservado = false;
        bool comentario = false;

        public static IDictionary<string, string> palavrasReservadas = new Dictionary<string, string>();
        public static IDictionary<string, string> simbolosReservadas = new Dictionary<string, string>();
        public static IDictionary<string, string> tiposReservados = new Dictionary<string, string>();

        public List<Char> caracterList = new List<char>();

        public Lexico(IDictionary<string, string> CompletePalavrasReservadas, IDictionary<string, string>  CompleteSibolosReservados, IDictionary<string, string> CompleteTiposReservados)
        {
            palavrasReservadas = CompletePalavrasReservadas;
            simbolosReservadas = CompleteSibolosReservados;
            tiposReservados = CompleteTiposReservados;
        }

        public bool RecebeCaracter(char caracter, bool nextLine)
        {
            if (nextLine)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach(Char c in caracterList)
                {
                    stringBuilder.Append(c);
                }
                string lex = stringBuilder.ToString();
                caracterList.Clear();
            }
            if (!IsReservado(caracter))
                caracterList.Add(caracter);
            
            return reservado;
            //entrada.
        }

        private bool IsReservado(char c)
        {
            if (palavrasReservadas.ContainsKey(c.ToString()) || simbolosReservadas.ContainsKey(c.ToString()) || tiposReservados.ContainsKey(c.ToString()))
            {
                reservado = true;
                return true;
            }

            if(c == ' ')
            {
                reservado = true;
                return true;
            }

            return false;
        }
    }
}

