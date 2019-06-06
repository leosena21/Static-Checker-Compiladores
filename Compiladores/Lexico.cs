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
        public String Matricula;
        public String Nome;
        public float Salario;
        public int Dia;
        public int Mes;
        public int Ano;
        public String Setor;

        public Lexico(String line)
        {

            getMatricula(line);
            getNome(line);
            getSalario(line);
            getDia(line);
            getMes(line);
            getAno(line);
            getSetor(line);
        }

        public void getMatricula(String line)
        {
            String[] substrings = line.Split(';');
            Matricula = substrings[0];
            Console.WriteLine(Matricula);
        }

        public void getNome(String line)
        {
            String[] substrings = line.Split(';');
            Nome = substrings[1];
            Console.WriteLine(Nome);
        }

        public void getSalario(String line)
        {
            String[] substrings = line.Split(';');
            Salario = float.Parse(substrings[2]);
            Console.WriteLine(Salario);
        }

        public void getDia(String line)
        {
            String[] substrings = line.Split(';');
            Dia = int.Parse(substrings[3]);
            Console.WriteLine(Dia);
        }
        public void getMes(String line)
        {
            String[] substrings = line.Split(';');
            Mes = int.Parse(substrings[4]);
            Console.WriteLine(Mes);
        }
        public void getAno(String line)
        {
            String[] substrings = line.Split(';');
            Ano = int.Parse(substrings[5]);
            Console.WriteLine(Ano);
        }
        public void getSetor(String line)
        {
            String[] substrings = line.Split(';');
            Setor = substrings[6];
            Console.WriteLine(Setor);
        }

    }
}

