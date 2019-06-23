using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ENGCOMP022019_ANALISADORLEXICO
{
    public class AnalisadorLexico
    {
        StreamReader Reader { get; set; }
        Token tk;
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
                            tk.Categoria = new Categoria() { Nome = "INEXISTENTE", Codigo = 999 };
                            tk.Codigo = "INE";
                            tk.LinhasApareceu.Add(Program.linha);
                            return tk;
                        }
                        break;

                    case 1:
                        if (char.IsLetterOrDigit(character))
                        {
                            stringAux = stringAux + character;
                            if (char.IsLetterOrDigit((char)Reader.Peek()))
                            {
                                stringAux = stringAux + '\0';
                                estado = 24;
                            }
                            else
                                character = (char)Reader.Read();
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
