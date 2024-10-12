using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.LogicaAplicacion.ICasosUso.IPedidos;
using Papeleria.LogicaNegocio.Entidades.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosUso.Pedidos
{
    public class CUGetPedidoLast : ICUGetPedidoLast
    {
        public IRepositorioPedidos Repositorio {  get; set; }
        public CUGetPedidoLast(IRepositorioPedidos repositorio)
        {
            Repositorio = repositorio;
        }
        //Retorna el ultimo pedido de la base de datos
        public Pedido GetPedido()
        {
            return Repositorio.GetLastPedido();
        }
    }
}
