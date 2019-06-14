using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Compiladores
{
    public class Program
    {
        public static string path;
        public static string[] readText;
        public static bool nextLine = false;
        public static IDictionary<string, string> palavrasReservadas = new Dictionary<string, string>();
        public static IDictionary<string, string> simbolosReservadas = new Dictionary<string, string>();
        public static IDictionary<string, string> tiposReservados = new Dictionary<string, string>();
        static void Main(string[] args)
        {

            List<Lexico> Func = new List<Lexico>();

            Console.WriteLine("Digite ação:\n1-Informar nome do arquivo\n2-Path do arquivo");
            string resp = Console.ReadKey().KeyChar.ToString();

            switch (resp)
            {
                case "1":
                    Console.WriteLine("\nInforme nome do arquivo: ");
                    resp = Console.ReadLine().ToString();
                    path = $@"{Directory.GetCurrentDirectory()}/{resp}.191";
                    break;

                case "2":
                    Console.WriteLine("\nInforme path do arquivo: ");
                    resp = Console.ReadLine().ToString();
                    path = $@"resp";
                    break;
            }
            if (FileExist(path))
            {
                readText = File.ReadAllLines(path);
                if(readText != null)
                {
                    CompletePalavrasReservadas();
                    CompleteSibolosReservados();
                    CompleteTiposReservados();
                    Lexico lex = new Lexico(palavrasReservadas, simbolosReservadas, tiposReservados);

                    foreach(String line in readText)
                    {
                        foreach(char c in line.ToUpper())
                        {
                            if (lex.RecebeCaracter(c, nextLine))
                            {
                                InstantiateNewLex(lex);
                            }
                                nextLine = false;
                        }
                            nextLine = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nArquivo ou diretorio não encontrado! Reinicie a aplicação!");
                Console.ReadKey();
                Environment.Exit(1);
            }


            Console.ReadKey();

        }

        private static void InstantiateNewLex(Lexico lex)
        {
            lex = new Lexico(palavrasReservadas, simbolosReservadas, tiposReservados);
        }

        private static bool FileExist(String Path)
        {
            if (File.Exists(Path))
                return true;
            else
                return false;
        }

        private static void CompleteTiposReservados()
        {
            tiposReservados.Add("Character", "C01");
            tiposReservados.Add("Constant-String", "C02");
            tiposReservados.Add("Float-Number", "C03");
            tiposReservados.Add("Function", "C04");
            tiposReservados.Add("Identifier", "C05");
            tiposReservados.Add("Integer-Number", "C06");
        }

        private static void CompleteSibolosReservados()
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

        private static void CompletePalavrasReservadas()
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

