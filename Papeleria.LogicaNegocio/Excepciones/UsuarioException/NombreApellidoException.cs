using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.UsuarioException
{
    public class NombreApellidoException: Exception
    {
        public NombreApellidoException() { }
        public NombreApellidoException(string message) : base(message) { }
        public NombreApellidoException(string message,  Exception innerException) : base(message, innerException) { }
    }
}
