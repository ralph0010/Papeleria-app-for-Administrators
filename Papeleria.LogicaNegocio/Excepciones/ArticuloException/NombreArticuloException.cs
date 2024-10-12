using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.ArticuloException
{
    public class NombreArticuloException: Exception
    {
        public NombreArticuloException() { }
        public NombreArticuloException(string message) : base(message)
        {
        }
        public NombreArticuloException(string message, Exception innerException) : base(message, innerException) { }

    }
}
