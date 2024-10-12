using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.PedidosException
{
    public class PedidoException:Exception
    {
        public PedidoException() { }
        public PedidoException(string msg) : base(msg) { }
        public PedidoException(string msg,  Exception inner) : base(msg, inner) { }
    }
}
