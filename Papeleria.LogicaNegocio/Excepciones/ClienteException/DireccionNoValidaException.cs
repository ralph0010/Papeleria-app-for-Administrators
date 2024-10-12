using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.ClienteException
{
    public class DireccionNoValidaException: Exception
    {
        public DireccionNoValidaException() { }
        public DireccionNoValidaException(string message) : base(message) { }
        public DireccionNoValidaException(string message, Exception innerException) : base(message, innerException) { }

    }
}
