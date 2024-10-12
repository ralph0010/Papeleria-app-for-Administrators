using Papeleria.LogicaNegocio.Entidades.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IPedidos
{
    public interface ICUGetAllPedidos
    {
        //Retorna la lista de Pedidos de la base de datos
        IEnumerable<Pedido> GetAll();
    }
}
