using System;
using System.Collections.Generic;
using System.IO;

namespace ENGCOMP022019_ANALISADORLEXICO
{
    public class Program
    {
        public static IDictionary<string, string> palavrasReservadas = new Dictionary<string, string>();
        public static IDictionary<string, string> simbolosReservadas = new Dictionary<string, string>();
        public static IDictionary<string, string> tiposReservados    = new Dictionary<string, string>();
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
            reader = new StreamReader(namePath);
            AnalisadorLexico analisador = new AnalisadorLexico(reader);
            do
            {                
                ch = (char)reader.Read();
                token = analisador.Analex(ch);
                switch (token.Categoria.Codigo)
                {
                    case 0:
                        //printf("%s - ", "Identificador");
                        //printf("%s\n", tk.lexema);
                        break;

                    case 1:
                        //printf("%s - ", "Palavra Reservada");
                        //printf("%d\n", tk.codigo);
                        break;

                    case 2:
                        //printf("%s\n", "Operador e Sinal");
                        break;

                    case 3:
                        //printf("%s - ", "Inteiro");
                        //printf("%d\n", tk.valorInteiro);
                        break;

                    case 4:
                        //printf("%s - ", "Real");
                        //printf("%f\n", tk.valorFloat);
                        break;

                    case 5:
                        //printf("%s - ", "Caracter");
                        //printf("%c\n", tk.caractere);
                        break;

                    case 6:
                        //printf("%s - ", "Cadeia de Caracter");
                        //printf("%s\n", tk.lexema);
                        break;

                    case 7:
                        //printf("%s - ", "Booleano");
                        //printf("%s\n", tk.valorInteiro);
                        break;

                    case 8:
                        //printf("%s\n", "Inexistente");
                        break;
                }


                Tchar++;
            } while (!reader.EndOfStream);
            reader.Close();
            reader.Dispose();
            Console.WriteLine(" ");
            Console.ReadLine();
        }



        public static void CompleteTiposReservados()
        {
            tiposReservados.Add("Character", "C01");
            tiposReservados.Add("Constant-String", "C02");
            tiposReservados.Add("Float-Number", "C03");
            tiposReservados.Add("Function", "C04");
            tiposReservados.Add("Identifier", "C05");
            tiposReservados.Add("Integer-Number", "C06");
        }

        public static void CompleteSibolosReservados()
        {
            palavrasReservadas.Add("!=", "B01");
            palavrasReservadas.Add("#", "B01");
            palavrasReservadas.Add("&", "B02");
            palavrasReservadas.Add("(", "B03");
            palavrasReservadas.Add("/", "B04");
            palavrasReservadas.Add(";", "B05");
            palavrasReservadas.Add("[", "B06");
            palavrasReservadas.Add("{", "B07");
            palavrasReservadas.Add("+", "B08");
            palavrasReservadas.Add("<=", "B09");
            palavrasReservadas.Add("=", "B10");
            palavrasReservadas.Add(">=", "B11");

            palavrasReservadas.Add("!", "B12");
            palavrasReservadas.Add("%", "B13");
            palavrasReservadas.Add(")", "B14");
            palavrasReservadas.Add("*", "B15");
            palavrasReservadas.Add(",", "B16");
            palavrasReservadas.Add("]", "B17");
            palavrasReservadas.Add("|", "B18");
            palavrasReservadas.Add("}", "B19");
            palavrasReservadas.Add("<", "B20");
            palavrasReservadas.Add("==", "B21");
            palavrasReservadas.Add(">", "B22");
            palavrasReservadas.Add("-", "B23");

        }

        public static void CompletePalavrasReservadas()
        {
            palavrasReservadas.Add("Bool", "A01");
            palavrasReservadas.Add("While", "A02");
            palavrasReservadas.Add("Break", "A03");
            palavrasReservadas.Add("Void", "A04");
            palavrasReservadas.Add("Char", "A05");
            palavrasReservadas.Add("True", "A06");
            palavrasReservadas.Add("Else", "A07");
            palavrasReservadas.Add("String", "A08");
            palavrasReservadas.Add("End", "A09");
            palavrasReservadas.Add("Return", "A10");
            palavrasReservadas.Add("False", "A11");
            palavrasReservadas.Add("Program", "A12");
            palavrasReservadas.Add("Float", "A13");
            palavrasReservadas.Add("Int", "A14");
            palavrasReservadas.Add("If", "A15");
        }
    }
}
