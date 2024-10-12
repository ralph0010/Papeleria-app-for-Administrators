using Papeleria.LogicaNegocio.Entidades.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IPedidos
{
    public interface ICUGetPedidoLast
    {
        //Retorna el ultimo pedido
        Pedido GetPedido();
    }
}
