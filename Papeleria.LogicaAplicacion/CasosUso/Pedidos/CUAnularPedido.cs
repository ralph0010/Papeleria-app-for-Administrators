using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.LogicaAplicacion.ICasosUso.IPedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosUso.Pedidos
{
    public class CUAnularPedido : ICUAnularPedido
    {
        public IRepositorioPedidos Repositorio { get; set; }
        public CUAnularPedido(IRepositorioPedidos repositorio)
        {
            Repositorio = repositorio;
        }
        //Cambia el estado de un pedido y lo actualiza
        public void AnularPedido(int id)
        {
            Repositorio.AnularPedido(id);
        }
    }
}
