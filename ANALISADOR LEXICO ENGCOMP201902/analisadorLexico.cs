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

                        else
                        {
                            tk.Categoria = new Categoria() { Nome = "INEXISTENTE", Codigo = "NUL" };
                            tk.Codigo = "INE";
                            tk.LinhasApareceu.Add(Program.linha);
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
