using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.PedidosException
{
    public class ItemArticuloException:Exception
    {
        public ItemArticuloException() { }
        public ItemArticuloException(string msg) : base(msg) { }
        public ItemArticuloException(string msg, Exception inner) : base(msg, inner) { }
    }
}
