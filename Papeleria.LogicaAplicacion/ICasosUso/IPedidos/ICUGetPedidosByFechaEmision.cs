using Papeleria.LogicaNegocio.Entidades.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IPedidos
{
    public interface ICUGetPedidosByFechaEmision
    {
        //Retorna una lista de pedidos que la fecha recibida sea la misma que la fecha de emmisio del pedido
        IEnumerable<Pedido> GetPedidos(DateTime fecha);
    }
}
