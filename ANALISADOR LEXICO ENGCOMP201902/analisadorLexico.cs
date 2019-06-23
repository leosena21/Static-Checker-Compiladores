using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ENGCOMP022019_ANALISADORLEXICO
{
    public class AnalisadorLexico
    {
        StreamReader Reader { get; set; }
        Token tk = new Token();
        int i = 0;
        int j = 0;
        int estado = 0;
        char character;
        string stringAux;
        public AnalisadorLexico(StreamReader reader)
        {
            Reader = reader;
        }
        public Token Analex(char character)
        {
            character = Char.ToUpper(character);

            //char ch = (char)Reader.Read();
            //FAZER A ANALISE
            while (!Reader.EndOfStream)
            {
                character = Char.ToUpper(character);
                switch (estado)
                {
                    case 0:
                        if (character == ' ' || character == '\n' || character == '\t')
                        {
                            estado = 0;
                            if (character == '\n')
                                Program.linha++;
                            character = (char)Reader.Read();

                            break;
                        }
                        else if (char.IsLetter(character))
                        {
                            estado = 1;
                        }
                        else if (char.IsDigit(character))
                        {
                            estado = 2;
                        }
                        else if (character == '(')
                        {
                            estado = 3;
                        }
                        else if (character == ')')
                        {
                            estado = 4;
                        }
                        else if (character == '+')
                        {
                            estado = 5;
                        }
                        else if (character == '-')
                        {
                            estado = 6;
                        }
                        else if (character == '<')
                        {
                            estado = 9;
                        }
                        else if (character == '>')
                        {
                            estado = 10;
                        }
                        else if (character == '=')
                        {
                            estado = 11;
                        }
                        else if (character == ';')
                        {
                            estado = 14;
                        }
                        else if (character == ',')
                        {
                            estado = 15;
                        }
                        else if (character == '[')
                        {
                            estado = 16;
                        }
                        else if (character == ']')
                        {
                            estado = 17;
                        }
                        else
                        {
                            tk.Categoria = new Categoria() { Nome = "INEXISTENTE", Codigo = "NUL" };
                            tk.Codigo = "INE";

                            tk.LinhasApareceu.Add(Program.linha);
                            estado = 0;
                            return tk;
                        }
                        break;

                    case 1:
                        if (char.IsLetterOrDigit(character))
                        {
                            stringAux = stringAux + character;
                            if (!(char.IsLetterOrDigit((char)Reader.Peek())))
                            {
                                if(character != '-')
                                    estado = 24;
                            }
                            else
                                character = (char)Reader.Read();
                        }
                        break;

                    case 3:
                        tk.Categoria = new Categoria() {Nome ="ABRE_PARENTESES", Codigo = Program.palavrasReservadas[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        tk.Codigo = "SR";
                        estado = 0;
                        return tk;
                    case 4:
                        tk.Categoria = new Categoria() { Nome = "FECHA_PARENTESES", Codigo = Program.palavrasReservadas[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        tk.Codigo = "SR";
                        estado = 0;
                        return tk;
                    case 5:
                        tk.Categoria = new Categoria() { Nome = "MAIS", Codigo = Program.palavrasReservadas[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        tk.Codigo = "SR";
                        estado = 0;
                        return tk;
                    case 6:
                        tk.Categoria = new Categoria() { Nome = "MENOS", Codigo = Program.palavrasReservadas[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        tk.Codigo = "SR";
                        estado = 0;
                        return tk;
                    case 9:
                        
                        if ((char)Reader.Peek() == '=')
                        {
                            estado = 19;
                            stringAux = stringAux + character;
                            character = (char)Reader.Read();
                            stringAux = stringAux + character;
                        }                            
                        else
                        {
                            tk.Categoria = new Categoria() { Nome = "MENOR", Codigo = Program.palavrasReservadas[character.ToString()] };
                            tk.Lexeme = character.ToString();
                            tk.Codigo = "SR";
                            estado = 0;
                            return tk;
                        }
                        break;

                    case 10:
                        if ((char)Reader.Peek() == '=')
                        {
                            stringAux = stringAux + character;
                            estado = 20;
                            character = (char)Reader.Read();
                            stringAux = stringAux + character;
                        }
                        else
                        {
                            tk.Categoria = new Categoria() { Nome = "MAIOR", Codigo = Program.palavrasReservadas[character.ToString()] };
                            tk.Lexeme = character.ToString();
                            tk.Codigo = "SR";
                            estado = 0;
                            return tk;
                        }
                        break;
                    case 11:
                        if ((char)Reader.Peek() == '=')
                        {
                            stringAux = stringAux + character;
                            estado = 21;
                            character = (char)Reader.Read();
                            stringAux = stringAux + character;
                        }
                        else
                        {
                            tk.Categoria = new Categoria() { Nome = "ATRIBUICAO", Codigo = Program.palavrasReservadas[character.ToString()] };
                            tk.Lexeme = character.ToString();
                            tk.Codigo = "SR";
                            estado = 0;
                            return tk;
                        }
                        break;
                    case 14:
                        tk.Categoria = new Categoria() { Nome = "PONTO_E_VIRGULA", Codigo = Program.palavrasReservadas[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        tk.Codigo = "SR";
                        estado = 0;
                        return tk;
                    case 15:
                        tk.Categoria = new Categoria() { Nome = "VIRGULA", Codigo = Program.palavrasReservadas[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        tk.Codigo = "SR";
                        estado = 0;
                        return tk;
                    case 16:
                        tk.Categoria = new Categoria() { Nome = "ABRE_COLCHETES", Codigo = Program.palavrasReservadas[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        tk.Codigo = "SR";
                        estado = 0;
                        return tk;
                    case 17:
                        tk.Categoria = new Categoria() { Nome = "FECHA_COLCHETES", Codigo = Program.palavrasReservadas[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        tk.Codigo = "SR";
                        estado = 0;
                        return tk;
                    case 19:
                        tk.Categoria = new Categoria() { Nome = "MENOR_IGUAL", Codigo = Program.palavrasReservadas[character.ToString()] };
                        tk.Lexeme = stringAux;
                        tk.Codigo = "SR";
                        stringAux = "";
                        estado = 0;
                        return tk;
                    case 20:
                        tk.Categoria = new Categoria() { Nome = "MAIOR_IGUAL", Codigo = Program.palavrasReservadas[character.ToString()] };
                        tk.Lexeme = stringAux;
                        tk.Codigo = "SR";
                        stringAux = "";
                        estado = 0;
                        return tk;
                    case 21:
                        tk.Categoria = new Categoria() { Nome = "IGUAL", Codigo = Program.palavrasReservadas[character.ToString()] };
                        tk.Lexeme = stringAux;
                        tk.Codigo = "SR";
                        stringAux = "";
                        estado = 0;
                        return tk;



                    case 24:
                        var oLoco = Program.palavrasReservadas.ContainsKey(stringAux);
                        if (Program.palavrasReservadas.ContainsKey(stringAux))
                        {
                            tk.Lexeme = stringAux;
                            tk.Categoria = new Categoria() { Nome = stringAux, Codigo = Program.palavrasReservadas[stringAux] };
                            tk.Codigo = "PR";
                            stringAux = "";
                            estado = 0;
                            return tk;
                        }
                        else if (Program.tiposReservados.ContainsKey(stringAux))
                        {
                            tk.Lexeme = stringAux;
                            tk.Categoria = new Categoria() { Nome = stringAux, Codigo = Program.tiposReservados[stringAux] };
                            tk.Codigo = "TR";
                            stringAux = "";
                            estado = 0;
                            return tk;
                        }
                        character = (char)Reader.Read();
                        estado = 0;
                        break;
                    default:
                        break;
                }



            }
            return tk;
        }
    }
}
