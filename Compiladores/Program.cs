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
                readText = File.ReadAllLines(path);
            else
            {
                Console.WriteLine("\nDiretorio não encontrado, reinicie a aplicação!");
                Console.ReadKey();
                Environment.Exit(1);
            }


            Console.ReadKey();

        }


        public static bool FileExist(String Path)
        {
            if (File.Exists(Path))
                return true;
            else
                return false;
        }
    }
}

