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
    public class CUGetPedidosByFechaEmision : ICUGetPedidosByFechaEmision
    {
        public IRepositorioPedidos Repositorio { get; set; }
        public CUGetPedidosByFechaEmision(IRepositorioPedidos repositorio)
        {
            Repositorio = repositorio;
        }
        //Retorna pedidos con la misma fecha de emision en el cual recibe en el parametro
        public IEnumerable<Pedido> GetPedidos(DateTime fecha)
        {
            return Repositorio.GetPedidosByFechaEmision(fecha);
        }
    }
}
