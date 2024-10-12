using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.ArticuloException
{
    public class CodigoArticuloException: Exception
    {
        public CodigoArticuloException() { }
        public CodigoArticuloException(string message) : base(message) { }
        public CodigoArticuloException(string message, Exception innerException) : base(message, innerException) { }

    }
}
