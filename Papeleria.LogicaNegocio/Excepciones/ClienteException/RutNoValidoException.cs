using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.ClienteException
{
    public class RutNoValidoException:Exception
    {
        public RutNoValidoException() { }
        public RutNoValidoException(string message) : base(message) { }
        public RutNoValidoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
