using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.UsuarioException
{
    public class EmailInvalidoException:Exception
    {
        public EmailInvalidoException() { }
        public EmailInvalidoException(string message) : base(message) { }
        public EmailInvalidoException(string message,  Exception innerException) : base(message, innerException) { }
    }
}
