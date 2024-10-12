using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.PedidosException
{
    public class FechaPedidoException: Exception
    {
        public FechaPedidoException() { }
        public FechaPedidoException(string msg) : base(msg) { }
        public FechaPedidoException(string msg, Exception inner) : base(msg, inner) { }
    }
}
