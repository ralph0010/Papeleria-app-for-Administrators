using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IPedidos
{
    public interface ICUAnularPedido
    {
        //Cambia de estado anulado a un pedido de la base de datos mediante la id
        void AnularPedido(int id);
    }
}
