using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.UsuarioException
{
    public class PasswordInvalidaException: Exception
    {
        public PasswordInvalidaException() { }  
        public PasswordInvalidaException(string message) : base(message) { }
        public PasswordInvalidaException(string message,  Exception innerException) : base(message, innerException)
        {

        }
    }
}
