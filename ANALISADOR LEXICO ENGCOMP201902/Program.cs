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
            string namePath;
            Console.WriteLine("Digite o nome ou caminho do arquivo: \n");
            namePath = Console.ReadLine();
            namePath = namePath + ".191";
            char ch;
            int Tchar = 0;
            StreamReader reader;
            Token token;
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
                    case "PR":
                        Console.WriteLine("Palavra Reservada");
                        Console.WriteLine(token.Lexeme);
                        break;

                    case "TR":
                        Console.WriteLine("Tipo Reservado");
                        Console.WriteLine(token.Lexeme);
                        break;
                    case "INT":
                        Console.WriteLine("INTEIRO");
                        Console.WriteLine(token.Lexeme);
                        break;
                    case "FLO":
                        Console.WriteLine("FLOAT");
                        Console.WriteLine(token.Lexeme);
                        break;

                    //case 2:
                    //    //printf("%s\n", "Operador e Sinal");
                    //    break;

                    //case 3:
                    //    //printf("%s - ", "Inteiro");
                    //    //printf("%d\n", tk.valorInteiro);
                    //    break;

                    //case 4:
                    //    //printf("%s - ", "Real");
                    //    //printf("%f\n", tk.valorFloat);
                    //    break;

                    //case 5:
                    //    //printf("%s - ", "Caracter");
                    //    //printf("%c\n", tk.caractere);
                    //    break;

                    //case 6:
                    //    //printf("%s - ", "Cadeia de Caracter");
                    //    //printf("%s\n", tk.lexema);
                    //    break;

                    //case 7:
                    //    //printf("%s - ", "Booleano");
                    //    //printf("%s\n", tk.valorInteiro);
                    //    break;

                    case "INE":
                        Console.WriteLine(token.Categoria.Nome);
                        Console.WriteLine(token.Lexeme);
                        break;

                    case "COM":
                        break;
                    case "CH":
                        break;
                }


                Tchar++;
                analisador.ClearToken();
            } while (!reader.EndOfStream);
            reader.Close();
            reader.Dispose();
            Console.WriteLine(" ");
            Console.ReadLine();
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
