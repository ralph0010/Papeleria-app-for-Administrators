using Papeleria.LogicaNegocio.Entidades.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IPedidos
{
    public interface ICUAddPedidoToDatabase
    {
        //Agrega un pedido a la base de datos
        void AddPedido(Pedido pedido);
    }
}
