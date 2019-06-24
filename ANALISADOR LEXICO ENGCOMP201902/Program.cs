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
        public static int linha = 1;
        

        static void Main(string[] args)
        {
            StreamWriter arquivoTabela;
            StreamWriter relatorioLexica;
            string namePath = "";
            string CaminhoNome = "";
            while (!File.Exists(namePath))
            {
                Console.WriteLine("Digite o nome ou caminho do arquivo: \n");
                namePath = Console.ReadLine();
                if (namePath.Contains("\\"))
                {
                    String[] names = namePath.Split('\\');
                    int j = names.Length;
                    CaminhoNome = $@"{Directory.GetCurrentDirectory()}/" + names[j - 1];
                }
                else
                {
                    CaminhoNome = $@"{Directory.GetCurrentDirectory()}/" + namePath;
                }
                namePath = namePath + ".191";
                if (!File.Exists(namePath))
                    Console.WriteLine("Arquivo nao encontrado ou inexistente");
            }
            char ch;
            int Tchar = 0;
            StreamReader reader;
            //List<TabelaDeSimbolos> tabelaList = new List<TabelaDeSimbolos>();
            List<Token> tokensList = new List<Token>();
            List<Token> tokensListRelatorioAnalex = new List<Token>();
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
                    //case "PR":
                    //    Console.WriteLine("Palavra Reservada");
                    //    Console.WriteLine(token.Lexeme);
                    //    break;

                    //case "TR":
                    //    Console.WriteLine("Tipo Reservado");
                    //    Console.WriteLine(token.Lexeme);
                    //    break;
                    //case "INT":
                    //    Console.WriteLine("INTEIRO");
                    //    Console.WriteLine(token.Lexeme + " " + token.Tamanho1 + " " + token.Tamanho2);
                    //    break;
                    //case "FLO":
                    //    Console.WriteLine("FLOAT");
                    //    Console.WriteLine(token.Lexeme + " " + token.Tamanho1 + " " + token.Tamanho2);
                    //    break;
                    //case "IDT":
                    //    Console.WriteLine(token.Categoria.Nome);
                    //    Console.WriteLine(token.Lexeme);
                    //    break;
                    //case "FUN":
                    //    Console.WriteLine(token.Categoria.Nome);
                    //    break;
                    //case "SR":
                    //    Console.WriteLine("Simbolo Reservado");
                    //    Console.WriteLine(token.Lexeme);
                    //    break;

                    case "INE":
                        break;

                    case "COM":
                        break;

                    default:
                        if(tokensList.Exists(x=> x.Lexeme == token.Lexeme))
                        {
                            Token t = tokensList.Find(x => x.Lexeme == token.Lexeme);
                            if(t.LinhasApareceu.Count<5)
                                t.LinhasApareceu.Add(token.LinhasApareceu[0]);
                        }
                        else
                        {
                            List<int> linhas = new List<int>();
                            foreach(int linha in token.LinhasApareceu)
                            {
                                linhas.Add(linha);
                            }
                            tokensList.Add(new Token(token, linhas));
                        }
                        tokensListRelatorioAnalex.Add(new Token(token));
                        break;
                }


                Tchar++;
                analisador.ClearToken();
            } while (!reader.EndOfStream);

            reader.Close();
            reader.Dispose();

            
            //TABELA DE SIMBOLOS                    
            arquivoTabela = File.CreateText(CaminhoNome + ".TAB");  //utilizando o metodo para criar um arquivo texto e associando o caminho e nome ao metodo                      
            arquivoTabela.WriteLine("RELATORIO DA TABELA DE SIMBOLOS"); //escrevendo o titulo   
            arquivoTabela.WriteLine("EQUIPE BRULEOTAR");
            arquivoTabela.WriteLine("NOME: BRUNA ANDRADE      TEL: 071-999509445   EMAIL: brunar2d2@gmail.com ");
            arquivoTabela.WriteLine("NOME: LEONARDO SENA     TEL: 071-99249-2638   EMAIL: leeosena21@gmail.com ");
            arquivoTabela.WriteLine("NOME: TARCIO CARVALHO      TEL:071-992284977   EMAIL: tarcioc2@gmail.com  ");
            arquivoTabela.WriteLine("");
            arquivoTabela.WriteLine("DETALHES \n");
            arquivoTabela.WriteLine("estrutura:   índice | Código | Lexeme | Tamanho antes de truncar | Tamanho depois de truncar | Categoria | Linhas que apareceu");


            int i = 0;
            foreach (Token tok in tokensList)
            {
                arquivoTabela.Write($"{i} | {tok.Categoria.Codigo} | {tok.Lexeme} | {tok.Tamanho1} | {tok.Tamanho2} | {tok.Codigo} | ");
                for(int j = 0; j< tok.LinhasApareceu.Count; j++)
                {
                    arquivoTabela.Write(tok.LinhasApareceu[j].ToString() + ",");
                }
                arquivoTabela.WriteLine();
                i++;

            }

            arquivoTabela.Close(); //fechando o arquivo texto com o método .Close()

            //RELATORIA ANALISE LEXICA
            relatorioLexica = File.CreateText(CaminhoNome + ".LEX");
            relatorioLexica.WriteLine("RELATORIO DA ANALISE LEXICA");
            relatorioLexica.WriteLine("EQUIPE BRULEOTAR");
            relatorioLexica.WriteLine("NOME: BRUNA ANDRADE      TEL: 071-999509445   EMAIL: brunar2d2@gmail.com ");
            relatorioLexica.WriteLine("NOME: LEONARDO SENA     TEL: 071-99249-2638   EMAIL: leeosena21@gmail.com ");
            relatorioLexica.WriteLine("NOME: TARCIO CARVALHO      TEL:071-992284977   EMAIL: tarcioc2@gmail.com  ");
            relatorioLexica.WriteLine("");
            relatorioLexica.WriteLine("DETALHES \n");
            relatorioLexica.WriteLine("estrutura:   lexeme | codigoAtomo | IndiceTabelaSimbolos");

            int k = 1;
            foreach (Token tok in tokensListRelatorioAnalex)
            {
                int indiceTabSimb = tokensList.FindIndex(x => x.Codigo == tok.Codigo);
                relatorioLexica.WriteLine($"{k} | {tok.Lexeme} | {tok.Categoria.Codigo} | {indiceTabSimb}");
                k++;

            }

            relatorioLexica.Close();


            Console.WriteLine("ANALISE FINALIZADA. PRESSIONE ENTER PARA ENCERRAR.");
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
