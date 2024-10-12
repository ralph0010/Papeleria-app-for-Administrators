using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades.CodigoComun
{
    
    public class MetodosComun
    {
        public MetodosComun() { }
        //Verifica si el string no contiene digitos
        public static bool NoEsDigito(string digito)
        {
            bool ret = false;
            char c;
            for (int i = 0; i < digito.Length && !ret; i++)
            {
                c = digito[i];
                if (!char.IsDigit(c))
                {
                    ret = true;
                }
            }
            return ret;
        }
        //Verifica que el paramatro pasado sea int
        public static bool EsInt(int numero)
        {
            int parse;
            if(int.TryParse(numero.ToString(), out parse))
            {
                return true;
            }
            return false;
        }
    }
}
