using Papeleria.LogicaNegocio.Entidades.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IPedidos
{
    public interface ICUGetTipoPedidoById
    {
        //Retorna el tipo de pedido segun el valor recibido
        TipoPedido GetTipoPedido(int id);
    }
}
