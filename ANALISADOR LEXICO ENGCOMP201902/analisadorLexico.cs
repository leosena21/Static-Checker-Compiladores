using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ENGCOMP022019_ANALISADORLEXICO
{
    public class AnalisadorLexico
    {
        StreamReader Reader { get; set; }
        Token tk = new Token() {Codigo = "COM"};
        //int i = 0;
        //int j = 0;
        int estado = 0;
        int contadorChar;
        //char character;
        string stringAux;
        bool existeChar;
        bool last = false;
        public AnalisadorLexico(StreamReader reader)
        {
            Reader = reader;
        }

        public void ClearToken()
        {
            estado = 0;
            stringAux = null;
            tk.Caractere = ' ';
            tk.Lexeme = "";
            tk.Codigo = null;
            tk.LinhasApareceu.Clear();
        }

        private void Tam(String stringAux)
        {
            if (stringAux.Length > 35)
            {
                tk.Tamanho1 = 35;
                tk.Tamanho2 = stringAux.Length;
                tk.Lexeme = stringAux.Substring(0, 35);
            }
            else
            {
                tk.Tamanho1 = stringAux.Length;
                tk.Tamanho2 = 0;
            }
        }

        private void AddLinha(int linha)
        {
            tk.LinhasApareceu.Add(linha);
        }
        public Token Analex(char character)
        {
            character = Char.ToUpper(character);

            //char ch = (char)Reader.Read();
            //FAZER A ANALISE
            while ('T'=='T')
            {

                character = Char.ToUpper(character);
                switch (estado)
                {
                    case 0:
                        if (character == ' ' || character == '\n' || character == '\t' || character == '\r')
                        {
                            estado = 0;
                            if (character == '\n' || character == '\r')
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
                        else if (character == '&')
                        {
                            estado = 7;
                        }
                        else if (character == '#')
                        {
                            estado = 8;
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
                        else if (character == '!')
                        {
                            estado = 12;
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
                        else if (character == '{')
                        {
                            estado = 18;
                        }
                        else if (character == '}')
                        {
                            estado = 22;
                        }
                        else if (character == '%')
                        {
                            estado = 23;
                        }
                        else if (character == '*')
                        {
                            estado = 25;
                        }
                        else if (character == '|')
                        {
                            estado = 26;
                        }
                        else if (character == '/')
                        {
                            estado = 27;
                        }
                        else if (character == '\'')
                        {
                            estado = 34;
                            stringAux = stringAux + character;
                        }
                        else if (character == '\"')
                        {
                            estado = 35;
                            stringAux = stringAux + character;
                            contadorChar++;
                        }
                        else if (character == '_')
                        {
                            estado = 36;
                            stringAux = stringAux + character;
                            contadorChar++;
                        }
                        else
                        {
                            tk.Categoria = new Categoria() { Nome = "INEXISTENTE", Codigo = "NUL" };
                            tk.Codigo = "INE";
                            tk.Lexeme = "";
                            AddLinha(Program.linha);
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
                                if (character == '\n')
                                    Program.linha++;
                                character = (char)Reader.Read();
                        }
                        break;

                    case 2:
                        if (char.IsDigit(character))
                            stringAux = stringAux + character;
                        else if(character == '.')
                        {
                            stringAux = stringAux + character;
                            estado = 30;
                        }
                        if (!(char.IsDigit((char)Reader.Peek())) && (char)Reader.Peek() != '.' && estado !=30)
                        {
                            estado = 31;
                        }
                        else
                        {
                            if (character == '\n')
                                Program.linha++;
                            if (estado != 30)
                                character = (char)Reader.Read();
                        }

                        break;

                    case 3:
                        tk.Categoria = new Categoria() {Nome ="ABRE_PARENTESES", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;
                    case 4:
                        tk.Categoria = new Categoria() { Nome = "FECHA_PARENTESES", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;
                    case 5:
                        tk.Categoria = new Categoria() { Nome = "MAIS", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;
                    case 6:
                        tk.Categoria = new Categoria() { Nome = "MENOS", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;
                    case 7:
                        tk.Categoria = new Categoria() { Nome = "E_COMERCIAL", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;
                    case 8:
                        tk.Categoria = new Categoria() { Nome = "SHARP", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
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
                            tk.Categoria = new Categoria() { Nome = "MENOR", Codigo = Program.simbolosReservados[character.ToString()] };
                            tk.Lexeme = character.ToString();
                            Tam(tk.Lexeme);
                            tk.Codigo = "SR";
                            AddLinha(Program.linha);
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
                            tk.Categoria = new Categoria() { Nome = "MAIOR", Codigo = Program.simbolosReservados[character.ToString()] };
                            tk.Lexeme = character.ToString();
                            Tam(tk.Lexeme);
                            tk.Codigo = "SR";
                            AddLinha(Program.linha);
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
                            tk.Categoria = new Categoria() { Nome = "ATRIBUICAO", Codigo = Program.simbolosReservados[character.ToString()] };
                            tk.Lexeme = character.ToString();
                            Tam(tk.Lexeme);
                            tk.Codigo = "SR";
                            AddLinha(Program.linha);
                            estado = 0;
                            return tk;
                        }
                        break;
                    case 12:
                        if ((char)Reader.Peek() == '=')
                        {
                            estado = 13;
                            stringAux = stringAux + character;
                            character = (char)Reader.Read();
                            stringAux = stringAux + character;
                        }
                        else
                        {
                            tk.Categoria = new Categoria() { Nome = "EXCLAMACAO", Codigo = Program.simbolosReservados[character.ToString()] };
                            tk.Lexeme = character.ToString();
                            Tam(tk.Lexeme);
                            tk.Codigo = "SR";
                            AddLinha(Program.linha);
                            estado = 0;
                            return tk;
                        }
                        break;
                    case 13:
                        tk.Categoria = new Categoria() { Nome = "DIFERENTE", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = stringAux;
                        Tam(stringAux);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        stringAux = "";
                        estado = 0;
                        return tk;
                    case 14:
                        tk.Categoria = new Categoria() { Nome = "PONTO_E_VIRGULA", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;
                    case 15:
                        tk.Categoria = new Categoria() { Nome = "VIRGULA", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;
                    case 16:
                        tk.Categoria = new Categoria() { Nome = "ABRE_COLCHETES", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;
                    case 17:
                        tk.Categoria = new Categoria() { Nome = "FECHA_COLCHETES", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;
                    case 18:
                        tk.Categoria = new Categoria() { Nome = "ABRE_CHAVES", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;
                    case 22:
                        tk.Categoria = new Categoria() { Nome = "FECHA_CHAVES", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;
                    case 19:
                        tk.Categoria = new Categoria() { Nome = "MENOR_IGUAL", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = stringAux;
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        stringAux = "";
                        estado = 0;
                        return tk;
                    case 20:
                        tk.Categoria = new Categoria() { Nome = "MAIOR_IGUAL", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = stringAux;
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        stringAux = "";
                        estado = 0;
                        return tk;
                    case 21:
                        tk.Categoria = new Categoria() { Nome = "IGUAL", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = stringAux;
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        stringAux = "";
                        estado = 0;
                        return tk;
                    case 23:
                        tk.Categoria = new Categoria() { Nome = "PERCENTUAL", Codigo = Program.simbolosReservados[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;
                    case 24:
                        if (Program.palavrasReservadas.ContainsKey(stringAux))
                        {
                            tk.Lexeme = stringAux;
                            tk.Categoria = new Categoria() { Nome = stringAux, Codigo = Program.palavrasReservadas[stringAux] };
                            Tam(tk.Lexeme);
                            tk.Codigo = "PR";
                            AddLinha(Program.linha);
                            stringAux = "";
                            estado = 0;
                            return tk;
                        }
                        else if (Program.tiposReservados.ContainsKey(stringAux))
                        {
                            tk.Lexeme = stringAux;
                            tk.Categoria = new Categoria() { Nome = stringAux, Codigo = Program.tiposReservados[stringAux] };
                            Tam(tk.Lexeme);
                            tk.Codigo = "TR";
                            AddLinha(Program.linha);
                            stringAux = "";
                            estado = 0;
                            return tk;
                        }
                        else if (!(stringAux.Contains("-")))
                        {
                            estado = 36;
                        }
                        else
                        {
                            stringAux = "";
                            character = (char)Reader.Read();
                            estado = 0;
                        }
                        break;
                    case 25:
                        tk.Categoria = new Categoria() { Nome = "ASTERISCO", Codigo = Program.palavrasReservadas[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;                   
                    case 26:
                        tk.Categoria = new Categoria() { Nome = "PIPE", Codigo = Program.palavrasReservadas[character.ToString()] };
                        tk.Lexeme = character.ToString();
                        Tam(tk.Lexeme);
                        tk.Codigo = "SR";
                        AddLinha(Program.linha);
                        estado = 0;
                        return tk;
                    case 27:
                        if ((char)Reader.Peek() == '/')
                        {
                            estado = 28;
                            character = (char)Reader.Read();                           
                        }
                        else if ((char)Reader.Peek() == '*')
                        {
                            estado = 29;
                            character = (char)Reader.Read();
                            character = (char)Reader.Read();
                        }
                        else
                        {
                            tk.Categoria = new Categoria() { Nome = "DIVISAO", Codigo = Program.palavrasReservadas[character.ToString()] };
                            tk.Lexeme = character.ToString();
                            Tam(tk.Lexeme);
                            tk.Codigo = "SR";
                            AddLinha(Program.linha);
                            estado = 0;
                            return tk;
                        }
                        break;
                    case 28:
                        if(character == '\n')
                        {
                            estado = 0;
                            Program.linha++;
                        }
                        else
                        {
                            character = (char)Reader.Read();
                        }
                        break;

                    case 29:
                        if (character == '*')
                        {
                            character = (char)Reader.Read();
                            if (character == '/')
                            {
                                estado = 0;
                                character = (char)Reader.Read();
                            }
                        }
                        else
                        {
                            if (character == '\n')
                                Program.linha++;
                            character = (char)Reader.Read();
                        }
                        character = (char)Reader.Read();
                        estado = 0;
                        break;
                    case 30://case26
                        if (char.IsDigit((char)Reader.Peek()))
                        {
                            character = (char)Reader.Read();
                            estado = 32;
                        }
                        else
                        {
                            Console.WriteLine("Tentativa de formar um float");
                            tk.Categoria = new Categoria() { Nome = "INEXISTENTE", Codigo = "NUL" };
                            tk.Lexeme = stringAux;
                            Tam(tk.Lexeme);
                            tk.Codigo = "INE";
                            AddLinha(Program.linha);
                            return tk;
                        }
                        break;
                    case 31: //case25
                        tk.Categoria = new Categoria() { Nome = "INTEIRO", Codigo = "INT" };
                        tk.Lexeme = stringAux;
                        Tam(tk.Lexeme);
                        tk.Codigo = "INT";
                        Tam(stringAux);
                        return tk;
                    case 32://case 27

                        if (char.IsDigit((char)Reader.Peek()))
                        {
                            stringAux = stringAux + character;
                            character = (char)Reader.Read();
                        }
                        else
                        {
                            stringAux = stringAux + character;
                            estado = 33;
                        }
                        break;
                    case 33:
                        tk.Categoria = new Categoria() { Nome = "FLOAT", Codigo = "FLO" };
                        tk.Lexeme = stringAux;
                        Tam(tk.Lexeme);
                        tk.Codigo = "FLO";
                        AddLinha(Program.linha);
                        Tam(stringAux);
                        return tk;

                    case 34:
                        if (Char.GetUnicodeCategory((char)Reader.Peek()) != UnicodeCategory.Control && (char)Reader.Peek() != '\\')
                        {
                            if(existeChar && (char)Reader.Peek() == '\'')
                            {
                                character = (char)Reader.Read();
                                stringAux = stringAux + character;
                                tk.Categoria = new Categoria() { Nome = "CHAR", Codigo = "CH" };
                                tk.Lexeme = stringAux;
                                Tam(tk.Lexeme);
                                tk.Codigo = "CH";
                                AddLinha(Program.linha);
                                estado = 0;
                                existeChar = false;
                                stringAux = "";
                                character = (char)Reader.Read();
                                return tk;
                            }
                            if (!existeChar)
                            {
                                character = (char)Reader.Read();
                                stringAux = stringAux + character;
                                existeChar = true;
                            }
                            else
                            {
                                if(character != '\'')
                                    character = (char)Reader.Read();
                                else
                                {
                                    if (character == '\n')
                                        Program.linha++;
                                    character = (char)Reader.Read();
                                    existeChar = false;
                                    stringAux = "";
                                    estado = 0;
                                }
                            }
                        }
                        else
                        {
                            tk.Categoria = new Categoria() { Nome = "INEXISTENTE", Codigo = "NUL" };
                            tk.Codigo = "INE";
                            tk.Lexeme = "";
                            AddLinha(Program.linha);
                            estado = 0;
                            return tk;
                        }
                        break;

                    case 35:
                        if (Char.GetUnicodeCategory((char)Reader.Peek()) != UnicodeCategory.Control && (char)Reader.Peek() != '\\')
                        {
                            if (character == '\n')
                                Program.linha++;
                            if ((char)Reader.Peek() == '\"')
                            {
                                character = (char)Reader.Read();
                                stringAux = stringAux + character;
                                contadorChar++;
                                tk.Categoria = new Categoria() { Nome = "CONSTANT-STRING", Codigo = "ST" };
                                tk.Lexeme = stringAux;
                                tk.Codigo = "ST";
                                AddLinha(Program.linha);
                                tk.Tamanho2 = contadorChar;
                                estado = 0;
                                stringAux = "";
                                contadorChar = 0;
                                character = (char)Reader.Read();
                                return tk;
                            }
                            if (stringAux.Length <= 34)
                            {
                                character = (char)Reader.Read();
                                stringAux = stringAux + character;
                                contadorChar++;
                            }
                            else
                            {                               
                                if (Reader.EndOfStream)
                                {
                                    tk.Categoria = new Categoria() { Nome = "INEXISTENTE", Codigo = "NUL" };
                                    tk.Codigo = "INE";
                                    tk.Lexeme = "";
                                    AddLinha(Program.linha);
                                    estado = 0;
                                    contadorChar = 0;
                                    stringAux = "";                                   
                                    return tk;
                                }
                                character = (char)Reader.Read();
                                contadorChar++;
                            }
                        }
                        else
                        {
                            tk.Categoria = new Categoria() { Nome = "INEXISTENTE", Codigo = "NUL" };
                            tk.Codigo = "INE";
                            tk.Lexeme = "";
                            AddLinha(Program.linha);
                            estado = 0;
                            contadorChar = 0;
                            stringAux = "";
                            return tk;
                        }
                        break;
                    case 36:
                        if((char.IsLetterOrDigit((char)Reader.Peek())) || (char)Reader.Peek() == '_')
                        {
                            character = (char)Reader.Read();
                            if(stringAux.Length < 35)
                                stringAux = stringAux + character;
                            contadorChar++;

                        }
                        else
                        {
                            if((char)Reader.Peek() == '(')
                            {
                                tk.Categoria = new Categoria() { Nome = "FUNCTION", Codigo = "FUN" };
                                tk.Lexeme = stringAux;
                                tk.Codigo = "FUN";
                                AddLinha(Program.linha);
                                tk.Tamanho2 = contadorChar;
                            }
                            else
                            {
                                tk.Categoria = new Categoria() { Nome = "IDENTIFIER", Codigo = "IDT" };
                                tk.Lexeme = stringAux;
                                tk.Codigo = "IDT";
                                AddLinha(Program.linha);
                                tk.Tamanho2 = contadorChar;
                            }
                            ClearToken();
                            estado = 0;
                        }

                        break;
                    default:
                        break;
                }



            }
            return tk;
        }
    }
}
