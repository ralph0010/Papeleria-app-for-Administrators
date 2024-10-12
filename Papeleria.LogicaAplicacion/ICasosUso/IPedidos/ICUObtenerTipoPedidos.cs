using Papeleria.LogicaNegocio.Entidades.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IPedidos
{
    public interface ICUObtenerTipoPedidos
    {
        //Retorna una lista los tipos de pedidos de la base de datos
        IEnumerable<TipoPedido> ObtenerTipos();
    }
}
