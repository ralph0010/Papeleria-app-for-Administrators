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
    public class CUGetTipoPedidoById : ICUGetTipoPedidoById
    {
        public IRepositorioTipoPedido Repositorio {  get; set; }
        public CUGetTipoPedidoById(IRepositorioTipoPedido repositorio)
        {
            Repositorio = repositorio;
        }
        //Retorna un tipo de pedido mediante el id
        public TipoPedido GetTipoPedido(int id)
        {
            return Repositorio.GetById(id);
        }
    }
}
