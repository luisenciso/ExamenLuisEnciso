using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    public class ChangeString
    {

        public String build(String StrCadena)
        {
            
            String StrSalida = String.Empty;
            String StrCaracter = String.Empty;
            bool BoSiMinus = false;

            for (int i = 0; i < StrCadena.Length; i++)
            {
                StrCaracter = StrCadena.Substring(i, 1);
                if (Char.IsLower(StrCaracter[0]))
                {
                    BoSiMinus = true;
                }
                else
                {
                    StrCaracter = StrCaracter.ToLower();
                }
                switch (StrCaracter)
                {
                    case "a":
                        StrCaracter = "b";
                        break;
                    case "b":
                        StrCaracter = "c";
                        break;
                    case "c":
                        StrCaracter = "d";
                        break;
                    case "d":
                        StrCaracter = "e";
                        break;
                    case "e":
                        StrCaracter = "f";
                        break;
                    case "f":
                        StrCaracter = "g";
                        break;
                    case "g":
                        StrCaracter = "h";
                        break;
                    case "h":
                        StrCaracter = "i";
                        break;
                    case "i":
                        StrCaracter = "j";
                        break;
                    case "j":
                        StrCaracter = "k";
                        break;
                    case "k":
                        StrCaracter = "l";
                        break;
                    case "l":
                        StrCaracter = "m";
                        break;
                    case "m":
                        StrCaracter = "n";
                        break;
                    case "n":
                        StrCaracter = "ñ";
                        break;
                    case "ñ":
                        StrCaracter = "o";
                        break;
                    case "o":
                        StrCaracter = "p";
                        break;
                    case "p":
                        StrCaracter = "q";
                        break;
                    case "q":
                        StrCaracter = "r";
                        break;
                    case "r":
                        StrCaracter = "s";
                        break;
                    case "s":
                        StrCaracter = "t";
                        break;
                    case "t":
                        StrCaracter = "u";
                        break;
                    case "u":
                        StrCaracter = "v";
                        break;
                    case "v":
                        StrCaracter = "w";
                        break;
                    case "w":
                        StrCaracter = "x";
                        break;
                    case "x":
                        StrCaracter = "y";
                        break;
                    case "y":
                        StrCaracter = "z";
                        break;
                    case "z":
                        StrCaracter = "a";
                        break;                    
                }
                if (!BoSiMinus){
                    StrCaracter = StrCaracter.ToUpper();
                }
                BoSiMinus = false;
                StrSalida = StrSalida + StrCaracter;
            }

            return StrSalida;
        }

    }
}
