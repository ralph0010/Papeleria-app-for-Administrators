using Papeleria.DTOs.DtoPedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.IPedidos
{
     public interface ICUObtenerPedidosAnulados
    {
        //Retorna la lista de pedidos ordenados por fecha descendente
        //Y lo castea a una lista de dtoPedidos
        IEnumerable<DtoObtenerPedidos> ObtenerPedidos();
       
    }
}
