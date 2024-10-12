using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.PedidosException
{
    public class TipoPedidoException:Exception
    {
        public TipoPedidoException() { }
        public TipoPedidoException(string msg) :base (msg){ }
        public TipoPedidoException(string msg, Exception inner) : base(msg, inner) { }
    }
}
