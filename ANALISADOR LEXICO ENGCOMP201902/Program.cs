using ANALISADOR_LEXICO_ENGCOMP201902;
using System;
using System.Collections.Generic;
using System.IO;

namespace ENGCOMP022019_ANALISADORLEXICO
{
    public class Program
    {
        public static IDictionary<string, string> palavrasReservadas = new Dictionary<string, string>();
        public static IDictionary<string, string> simbolosReservados = new Dictionary<string, string>();
        public static IDictionary<string, string> tiposReservados = new Dictionary<string, string>();
        public static int linha = 0;
        

        static void Main(string[] args)
        {
            StreamWriter arquivoTabela;
            string namePath;
            Console.WriteLine("Digite o nome ou caminho do arquivo: \n");
            namePath = Console.ReadLine();
            string CaminhoNome = $@"{Directory.GetCurrentDirectory()}/Leo.TAB";
            namePath = namePath + ".191";
            char ch;
            int Tchar = 0;
            StreamReader reader;
            //List<TabelaDeSimbolos> tabelaList = new List<TabelaDeSimbolos>();
            List<Token> tokensList = new List<Token>();
            Token token;
            //TabelaDeSimbolos tabelinha;

            CompletePalavrasReservadas();
            CompleteSibolosReservados();
            CompleteTiposReservados();
            reader = new StreamReader(namePath);
            AnalisadorLexico analisador = new AnalisadorLexico(reader);
            do
            {
                ch = (char)reader.Read();
                token = analisador.Analex(ch);
                switch (token.Codigo)
                {

                    case "INE":
                        break;

                    default:
                        tokensList.Add(new Token(token));
                        break;
                }


                Tchar++;
                analisador.ClearToken();
            } while (!reader.EndOfStream);

            reader.Close();
            reader.Dispose();
            Console.WriteLine(" ");
            Console.ReadLine();

            
            //TABELA DE SIMBOLOS                    
            arquivoTabela = File.CreateText(CaminhoNome);  //utilizando o metodo para criar um arquivo texto e associando o caminho e nome ao metodo                      
            arquivoTabela.WriteLine("Tabela de Símbolos"); //escrevendo o titulo   
            arquivoTabela.WriteLine(); //pulando linha sem escrita  

            int i = 1;
            foreach (Token tok in tokensList)
            {
                arquivoTabela.WriteLine($"{i} {tok.Categoria.Codigo} {tok.Lexeme} {tok.Tamanho1} {tok.Tamanho2} {tok.Codigo}");
                i++;

            }

            arquivoTabela.Close(); //fechando o arquivo texto com o método .Close()

        }
        
        public static void CompleteTiposReservados()
        {
            tiposReservados.Add("CHARACTER", "C01");
            tiposReservados.Add("CONSTANT-STRING", "C02");
            tiposReservados.Add("FLOAT-NUMBER", "C03");
            tiposReservados.Add("FUNCTION", "C04");
            tiposReservados.Add("IDENTIFIER", "C05");
            tiposReservados.Add("INTEGER-NUMBER", "C06");
        }

        public static void CompleteSibolosReservados()
        {
            simbolosReservados.Add("!=", "B01");
            simbolosReservados.Add("#", "B01");
            simbolosReservados.Add("&", "B02");
            simbolosReservados.Add("(", "B03");
            simbolosReservados.Add("/", "B04");
            simbolosReservados.Add(";", "B05");
            simbolosReservados.Add("[", "B06");
            simbolosReservados.Add("{", "B07");
            simbolosReservados.Add("+", "B08");
            simbolosReservados.Add("<=", "B09");
            simbolosReservados.Add("=", "B10");
            simbolosReservados.Add(">=", "B11");
            simbolosReservados.Add("!", "B12");
            simbolosReservados.Add("%", "B13");
            simbolosReservados.Add(")", "B14");
            simbolosReservados.Add("*", "B15");
            simbolosReservados.Add(",", "B16");
            simbolosReservados.Add("]", "B17");
            simbolosReservados.Add("|", "B18");
            simbolosReservados.Add("}", "B19");
            simbolosReservados.Add("<", "B20");
            simbolosReservados.Add("==", "B21");
            simbolosReservados.Add(">", "B22");
            simbolosReservados.Add("-", "B23");

        }

        public static void CompletePalavrasReservadas()
        {
            palavrasReservadas.Add("BOOL", "A01");
            palavrasReservadas.Add("WHILE", "A02");
            palavrasReservadas.Add("BREAK", "A03");
            palavrasReservadas.Add("VOID", "A04");
            palavrasReservadas.Add("CHAR", "A05");
            palavrasReservadas.Add("TRUE", "A06");
            palavrasReservadas.Add("ELSE", "A07");
            palavrasReservadas.Add("STRING", "A08");
            palavrasReservadas.Add("END", "A09");
            palavrasReservadas.Add("RETURN", "A10");
            palavrasReservadas.Add("FALSE", "A11");
            palavrasReservadas.Add("PROGRAM", "A12");
            palavrasReservadas.Add("FLOAT", "A13");
            palavrasReservadas.Add("INT", "A14");
            palavrasReservadas.Add("IF", "A15");
        }
    }
}
