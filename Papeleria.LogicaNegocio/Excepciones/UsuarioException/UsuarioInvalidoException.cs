using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.UsuarioException
{
    public class UsuarioInvalidoException: Exception
    {
        public UsuarioInvalidoException() { }
        public UsuarioInvalidoException(string message) : base(message)
        {

        }
        public UsuarioInvalidoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
